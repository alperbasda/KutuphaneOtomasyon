using System.Data.Entity;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.DataAccess.Concrete;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class FakulteManager : IFakulteService
    {
        private FakulteDal _fakulteDal;
        private IMapper _mapper;

        public FakulteManager(FakulteDal fakulteDal, IMapper mapper)
        {
            _fakulteDal = fakulteDal;
            _mapper = mapper;
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
    }
}