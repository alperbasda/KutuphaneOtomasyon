using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class KitapAnahtarManager:IKitapAnahtarService
    {
        private IKitapAnahtarDal _kitapAnahtarDal;
        private IQueryableRepositoryBase<KitapAnahtar> _queryable;
        private IMapper _mapper;

        public KitapAnahtarManager(IKitapAnahtarDal kitapAnahtarDal, IMapper mapper, IQueryableRepositoryBase<KitapAnahtar> queryable)
        {
            _kitapAnahtarDal = kitapAnahtarDal;
            _mapper = mapper;
            _queryable = queryable;
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

        public DataResponse KitapAnahtarGetirTablo(KitapAnahtarAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).ToList();
            int toplamData = model.Count(_queryable.Table);

            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitap Anahtarları Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<KitapAnahtarTabloModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
            };
        }
    }
}