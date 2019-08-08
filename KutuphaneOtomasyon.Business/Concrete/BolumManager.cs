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
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class BolumManager : IBolumService
    {
        private IBolumDal _bolumDal;
        private IMapper _mapper;
        private IQueryableRepositoryBase<Bolum> _queryable;

        public BolumManager(IBolumDal bolumDal, IMapper mapper, IQueryableRepositoryBase<Bolum> queryable)
        {
            _bolumDal = bolumDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumEkle(BolumEkleModel model)
        {
            var response = _bolumDal.SetState(_mapper.Map<Bolum>(model), EntityState.Added);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.BolumAdi + " Eklendi.",
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.BolumAdi + " Eklenmedi.",
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumGetirId(int id)
        {
            var data = _bolumDal.Find(id);
            if (data == null)
                return new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "Aradığınız Bolum Bulunamadı.",
                };
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Aradığınız Bolum Bulundu.",
                Data = _mapper.Map<BolumDuzenleModel>(data)
            };
        }


        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumDuzenle(BolumDuzenleModel model)
        {
            var response = _bolumDal.SetState(_mapper.Map<Bolum>(model), EntityState.Modified);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.BolumAdi + " düzenlendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.BolumAdi + " düzenlenirken hata oluştu"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumSil(int id)
        {
            var response = _bolumDal.Find(id);
            if (response != null)
            {
                _bolumDal.SetState(response, EntityState.Deleted);
                return new DataResponse
                {
                    Mesaj = "Bolum Silindi",
                    Tamamlandi = true,
                };
            }
            return new DataResponse
            {
                Mesaj = "Bolum Bulunamadı",
                Tamamlandi = false,
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumleriGetir(BolumAraModel model = null)
        {
            var bolumler = model != null ? model.ExecuteQueryables(_queryable.Table).ToList() : _bolumDal.GetList().ToList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Bölümler Listelendi!!!",
                Data = _mapper.Map<List<BolumSeciciModel>>(bolumler)
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumleriGetirTablo(BolumAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).ToList();
            int toplamData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Bölümler Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<BolumTabloModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
            };

        }
    }
}