using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        public DataResponse OgrenciGetirTablo(OgrenciAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).Include(s=>s.Bolum).ToList();
            var toplamData = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Ögrenciler Listelendi",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<OgrenciTabloModel>>(response),
                    ToplamSayfa = model.PageCount(toplamData),
                    ToplamData = toplamData
                }
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