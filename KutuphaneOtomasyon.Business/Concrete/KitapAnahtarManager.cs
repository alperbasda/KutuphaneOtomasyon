using System.Data.Entity;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class KitapAnahtarManager:IKitapAnahtarService
    {
        private IKitapAnahtarDal _kitapAnahtarDal;
        private IMapper _mapper;

        public KitapAnahtarManager(IKitapAnahtarDal kitapAnahtarDal, IMapper mapper)
        {
            _kitapAnahtarDal = kitapAnahtarDal;
            _mapper = mapper;
        }

        public DataResponse KitapAnahtarEkle(KitapAnahtarEkleModel model)
        {
            var response = _kitapAnahtarDal.SetState(_mapper.Map<KitapAnahtar>(model), EntityState.Added);
            if(response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.Anahtar + " Eklendi"
                };
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = model.Anahtar + " Eklenemedi"
            };
        }
    }
}