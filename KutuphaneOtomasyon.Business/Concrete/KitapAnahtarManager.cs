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

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapAnahtarGetirId(int id)
        {
            
            var data = _queryable.Table.Where(s=>s.Id==id).Include(s=>s.Kitap).FirstOrDefault();
            if (data == null)
                return new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "Aradığınız KitapAnahtar Bulunamadı.",
                };
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Aradığınız KitapAnahtar Bulundu.",
                Data = _mapper.Map<KitapAnahtarDuzenleModel>(data)
            };
        }


        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapAnahtarDuzenle(KitapAnahtarDuzenleModel model)
        {
            var response = _kitapAnahtarDal.SetState(_mapper.Map<KitapAnahtar>(model), EntityState.Modified);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.Anahtar + " düzenlendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.Anahtar + " düzenlenirken hata oluştu"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapAnahtarSil(int id)
        {
            var response = _kitapAnahtarDal.Find(id);
            if (response != null)
            {
                _kitapAnahtarDal.SetState(response, EntityState.Deleted);
                return new DataResponse
                {
                    Mesaj = "KitapAnahtar Silindi",
                    Tamamlandi = true,
                };
            }
            return new DataResponse
            {
                Mesaj = "KitapAnahtar Bulunamadı",
                Tamamlandi = false,
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