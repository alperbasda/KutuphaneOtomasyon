using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.Aspects.TransactionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Ogrenci;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciAdres;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciMail;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciTelefon;
using KutuphaneOtomasyon.Entities.Enum;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        private IOgrenciDal _ogrenciDal;
        private IQueryableRepositoryBase<Ogrenci> _queryable;
        private IMapper _mapper;


        public OgrenciManager(IOgrenciDal ogrenciDal, IMapper mapper, IQueryableRepositoryBase<Ogrenci> queryable)
        {
            _ogrenciDal = ogrenciDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [TransactionScopeAspect(AspectPriority = 2)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OgrenciEkle(OgrenciEkleModel model)
        {

            var response = _ogrenciDal.SetState(OgrenciDataDoldur(model), EntityState.Added);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.Numara + " numaralı ögrenci kayıt edildi",
                };
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = model.Numara + " numaralı ögrenci kayıt edilirken hata oluştu",
            };


        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OgrenciGetirId(int id)
        {
            
            var data = _queryable.Table.Where(s => s.Id == id).Include(s => s.OgrencininMailAdresleri)
                .Include(s => s.OgrencininAdresleri).Include(s => s.OgrencininTelefonlari).FirstOrDefault();
            if (data == null)
                return new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "Aradığınız Ogrenci Bulunamadı.",
                };
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Aradığınız Ogrenci Bulundu.",
                Data = _mapper.Map<OgrenciDuzenleModel>(data)
            };
        }


        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        [TransactionScopeAspect]
        public DataResponse OgrenciDuzenle(OgrenciDuzenleModel model)
        {
            var response = _ogrenciDal.SetState(_mapper.Map<Ogrenci>(model), EntityState.Modified);
            _ogrenciDal.AdresDuzenle(new OgrenciAdresEkleModel
            {
                Adres = model.OgrenciMemleketAdres,
                OgrenciId = model.Id,
                AdresTipi = AdresTipi.Ev
            });
            _ogrenciDal.AdresDuzenle(new OgrenciAdresEkleModel
            {
                Adres = model.OgrenciAdres,
                OgrenciId = model.Id,
                AdresTipi = AdresTipi.Okul
            });
            _ogrenciDal.MailDuzenle(new OgrenciMailEkleModel
            {
                MailAdresi = model.OgrenciMail,
                OgrenciId = model.Id,
            });
            _ogrenciDal.TelefonDuzenle(new OgrenciTelefonEkleModel
            {
                Telefon = model.OgrenciTelefon,
                OgrenciId = model.Id,
            });
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.Ad + " düzenlendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.Ad + " düzenlenirken hata oluştu"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OgrenciSil(int id)
        {
            var response = _ogrenciDal.Find(id);
            if (response != null)
            {
                _ogrenciDal.SetState(response, EntityState.Deleted);
                return new DataResponse
                {
                    Mesaj = "Ogrenci Silindi",
                    Tamamlandi = true,
                };
            }
            return new DataResponse
            {
                Mesaj = "Ogrenci Bulunamadı",
                Tamamlandi = false,
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OgrenciGetirTablo(OgrenciAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).Include(s=>s.Bolum).Include(s=>s.OgrencininMailAdresleri).Include(s=>s.OgrencininAdresleri).Include(s=>s.OgrencininTelefonlari).ToList();
            var toplamData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Ogrenciler Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<OgrenciTabloModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
            };

        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse OgrenciGetirOduncTablo(OgrenciAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).Include(s => s.OgrencininKitaplari).ToList();
            var toplamData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Ogrenciler Listelendi",
                Data = _mapper.Map<List<OgrenciOduncModel>>(response),
            };
        }

        private Ogrenci OgrenciDataDoldur(OgrenciEkleModel model)
        {
            Ogrenci ogrenci = _mapper.Map<Ogrenci>(model);
            ogrenci = OgrenciAdresEkle(ogrenci, new OgrenciAdresEkleModel { Adres = model.OgrenciAdres, AdresTipi = AdresTipi.Okul });
            ogrenci = OgrenciAdresEkle(ogrenci, new OgrenciAdresEkleModel { Adres = model.OgrenciMemleketAdres, AdresTipi = AdresTipi.Ev });
            ogrenci = OgrenciMailEkle(ogrenci, new OgrenciMailEkleModel { MailAdresi = model.OgrenciMail });
            ogrenci = OgrenciTelefonEkle(ogrenci, new OgrenciTelefonEkleModel { Telefon = model.OgrenciTelefon });
            return ogrenci;
        }

        private Ogrenci OgrenciAdresEkle(Ogrenci ogr, OgrenciAdresEkleModel model)
        {
            if(ogr.OgrencininAdresleri==null)
                ogr.OgrencininAdresleri= new List<OgrenciAdres>();
            ogr.OgrencininAdresleri.Add(_mapper.Map<OgrenciAdres>(model));
            return ogr;
        }
        private Ogrenci OgrenciTelefonEkle(Ogrenci ogr, OgrenciTelefonEkleModel model)
        {
            if (ogr.OgrencininTelefonlari == null)
                ogr.OgrencininTelefonlari = new List<OgrenciTelefon>();
            ogr.OgrencininTelefonlari.Add(_mapper.Map<OgrenciTelefon>(model));
            return ogr;
        }
        private Ogrenci OgrenciMailEkle(Ogrenci ogr, OgrenciMailEkleModel model)
        {
            if (ogr.OgrencininMailAdresleri == null)
                ogr.OgrencininMailAdresleri = new List<OgrenciMail>();
            ogr.OgrencininMailAdresleri.Add(_mapper.Map<OgrenciMail>(model));
            return ogr;
        }
    }
}