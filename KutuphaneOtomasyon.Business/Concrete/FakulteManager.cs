using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Concrete;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class FakulteManager : IFakulteService
    {
        private FakulteDal _fakulteDal;
        private IQueryableRepositoryBase<Fakulte> _queryable;
        private IMapper _mapper;

        public FakulteManager(FakulteDal fakulteDal, IMapper mapper, IQueryableRepositoryBase<Fakulte> queryable)
        {
            _fakulteDal = fakulteDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteEkle(FakulteEkleModel model)
        {
            bool sonuc = _fakulteDal.SetState(_mapper.Map<Fakulte>(model), EntityState.Added);
            if (sonuc)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.FakulteAdi + " Eklendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.FakulteAdi + " Eklenemedi"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteGetirId(int id)
        {
            var data = _fakulteDal.Find(id);
            if (data == null)
                return new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "Aradığınız Fakülte Bulunamadı.",
                };
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Aradığınız Fakülte Bulundu.",
                Data = _mapper.Map<FakulteDuzenleModel>(data)
            };
        }


        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteDuzenle(FakulteDuzenleModel model)
        {
            var response = _fakulteDal.SetState(_mapper.Map<Fakulte>(model), EntityState.Modified);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.FakulteAdi + " düzenlendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.FakulteAdi + " düzenlenirken hata oluştu"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteSil(int id)
        {
            var response = _fakulteDal.Find(id);
            if (response != null)
            {
                _fakulteDal.SetState(response, EntityState.Deleted);
                return new DataResponse
                {
                    Mesaj = "Fakülte Silindi",
                    Tamamlandi = true,
                };
            }
            return new DataResponse
            {
                Mesaj = "Fakülte Bulunamadı",
                Tamamlandi = false,
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteleriGetir(FakulteAraModel model = null)
        {
            var fakulteler = model?.ExecuteQueryables(_queryable.Table).ToList() ?? _fakulteDal.GetList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Fakulteler Listelendi !!!",
                Data = _mapper.Map<List<FakulteModel>>(fakulteler)
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteleriGetirTablo(FakulteAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).ToList();
            int toplamData = model.Count(_queryable.Table);

            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Fakulteler Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<FakulteModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
            };

        }


    }
}