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
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Kitap;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class KitapManager : IKitapService
    {
        private IKitapDal _kitapDal;
        private IQueryableRepositoryBase<Kitap> _queryable;
        private IMapper _mapper;

        public KitapManager(IMapper mapper, IKitapDal kitapDal, IQueryableRepositoryBase<Kitap> queryable)
        {
            _mapper = mapper;
            _kitapDal = kitapDal;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapEkle(KitapEkleModel model)
        {
            var response = _kitapDal.SetState(_mapper.Map<Kitap>(model), EntityState.Added);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.Adi + " kitabı kaydedildi.",
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.Adi + " kitabı kaydedilemedi.",
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapSeciciListele(KitapAraModel model = null)
        {
            var kitapListesi = model?.ExecuteQueryables(_queryable.Table).Select(s => new KitapSeciciModel { KitapAdi = s.Adi, Id = s.Id }).ToList() ?? _queryable.Table.Select(s => new KitapSeciciModel { KitapAdi = s.Adi, Id = s.Id }).ToList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitaplar Listelendi !!!",
                Data = kitapListesi
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitaplariGetirTablo(KitapAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).Include(s=>s.KitapKategori).ToList();
            int toplamData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitaplar Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<KitapTabloModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
            };

        }
    }
}