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
                    Mesaj = model.FakulteAdi +" Eklendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.FakulteAdi + " Eklenemedi"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteleriGetir(FakulteAraModel model)
        {
            var fakulteler = model != null ? model.ExecuteQueryables(_queryable.Table).ToList() : _fakulteDal.GetList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Fakulteler Listelendi !!!",
                Data = fakulteler
            };
        }
    }
}