using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Odunc;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Odunc;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class KitapHareketManager : IKitapHareketService
    {
        private IKitapHareketDal _kitapHareketDal;
        private IMapper _mapper;
        private IQueryableRepositoryBase<KitapHareket> _queryable;

        public KitapHareketManager(IKitapHareketDal kitapHareketDal, IMapper mapper, IQueryableRepositoryBase<KitapHareket> queryable)
        {
            _kitapHareketDal = kitapHareketDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OduncGetirTablo(OduncAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).Include(s => s.Ogrenci).Include(s => s.Kitap).ToList();
            int toplamData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitap Hareketleri Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<OduncTabloModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
            };

        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OduncEkle(int ogrenciId, int kitapId)
        {
            var response = _kitapHareketDal.SetState(new KitapHareket
            {
                OgrenciId = ogrenciId,
                KitapId = kitapId
            }, EntityState.Added);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = "Hareket Eklendi",

                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = "Hareket Eklenemedi",

            };

        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse TeslimAl(int id)
        {
            var item = _kitapHareketDal.Find(id);
            if (item == null)
                return new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "Kitap Teslim Alınamadı",
                };
            item.TeslimTarihi = DateTime.Now;
            _kitapHareketDal.SetState(item, EntityState.Modified);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitap Teslim Alındı",
            };
        }
    }
}