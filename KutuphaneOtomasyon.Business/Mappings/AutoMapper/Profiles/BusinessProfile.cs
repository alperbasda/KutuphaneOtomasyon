using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Kitap;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapKategori;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Odunc;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Ogrenci;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciAdres;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciMail;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciTelefon;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<FakulteEkleModel, Fakulte>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.FakulteAdi));
            CreateMap<FakulteDuzenleModel, Fakulte>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.FakulteAdi));
            CreateMap<Fakulte, FakulteDuzenleModel>()
                .ForMember(d => d.FakulteAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<Fakulte, FakulteModel>()
                .ForMember(d => d.FakulteAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<BolumEkleModel, Bolum>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.BolumAdi))
                .ForMember(d => d.FakulteId, t => t.MapFrom(v => v.FakulteId));
            CreateMap<BolumDuzenleModel, Bolum>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.BolumAdi))
                .ForMember(d => d.FakulteId, t => t.MapFrom(v => v.FakulteId));
            CreateMap<Bolum, BolumDuzenleModel>()
                .ForMember(d => d.BolumAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<Bolum, BolumSeciciModel>()
                .ForMember(d => d.BolumAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<Bolum, BolumTabloModel>()
                .ForMember(d => d.BolumAdi, t => t.MapFrom(v => v.Adi))
                .ForMember(d => d.FakulteId, t => t.MapFrom(v => v.FakulteId))
                .ForMember(d => d.FakulteAdi, t => t.MapFrom(v => v.Fakulte.Adi));
            CreateMap<KitapKategoriEkleModel, KitapKategori>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.KitapKategoriAdi));
            CreateMap<KitapKategoriDuzenleModel, KitapKategori>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.KitapKategoriAdi));
            CreateMap<KitapKategori, KitapKategoriDuzenleModel>()
                .ForMember(d => d.KitapKategoriAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<KitapKategori, KitapKategoriModel>()
                .ForMember(d => d.KitapKategoriAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<KitapEkleModel, Kitap>();
            CreateMap<KitapDuzenleModel, Kitap>();
            CreateMap<Kitap, KitapDuzenleModel>();
            CreateMap<Kitap, KitapSeciciModel>()
                .ForMember(d => d.KitapAdi, t => t.MapFrom(v => v.Adi));
            CreateMap<Kitap, KitapTabloModel>()
                .ForMember(d => d.KitapKategoriAdi, t => t.MapFrom(v => v.KitapKategori.Adi));
            CreateMap<KitapAnahtarEkleModel, KitapAnahtar>();
            CreateMap<KitapAnahtarDuzenleModel, KitapAnahtar>();
            CreateMap<KitapAnahtar, KitapAnahtarDuzenleModel>()
                .ForMember(d => d.KitapAd, t => t.MapFrom(v => v.Kitap.Adi));
            CreateMap<KitapAnahtar, KitapAnahtarTabloModel>()
                .ForMember(d => d.KitapAdi, t => t.MapFrom(v => v.Kitap.Adi));

            CreateMap<Ogrenci, OgrenciTabloModel>()
                .ForMember(d => d.BolumAdi, t => t.MapFrom(v => v.Bolum.Adi))
                .ForMember(d => d.Mail, t => t.MapFrom(v => v.OgrencininMailAdresleri.Where(s => !s.Silindi).First().MailAdresi))
                .ForMember(d => d.Telefon, t => t.MapFrom(v => v.OgrencininTelefonlari.Where(s => !s.Silindi).First().Telefon))
                .ForMember(d => d.MemleketAdres, t => t.MapFrom(v => v.OgrencininAdresleri.Where(s => !s.Silindi && s.AdresTipi == AdresTipi.Ev).First().Adres))
                .ForMember(d => d.Adres, t => t.MapFrom(v => v.OgrencininAdresleri.Where(s => !s.Silindi && s.AdresTipi == AdresTipi.Okul).First().Adres));

            CreateMap<OgrenciEkleModel, Ogrenci>();

            CreateMap<Ogrenci, OgrenciOduncModel>()
                .ForMember(d => d.ElindeKitapVarmi, t => t.MapFrom(v => v.OgrencininKitaplari.Count(s=>s.TeslimTarihi==null)));


            CreateMap<Ogrenci, OgrenciDuzenleModel>()
                .ForMember(d => d.OgrenciMail, t => t.MapFrom(v => v.OgrencininMailAdresleri.Where(s => !s.Silindi).First().MailAdresi))
                .ForMember(d => d.OgrenciTelefon, t => t.MapFrom(v => v.OgrencininTelefonlari.Where(s => !s.Silindi).First().Telefon))
                .ForMember(d => d.OgrenciMemleketAdres, t => t.MapFrom(v => v.OgrencininAdresleri.Where(s => !s.Silindi && s.AdresTipi == AdresTipi.Ev).First().Adres))
                .ForMember(d => d.OgrenciAdres, t => t.MapFrom(v => v.OgrencininAdresleri.Where(s => !s.Silindi && s.AdresTipi == AdresTipi.Okul).First().Adres)).ReverseMap();
            CreateMap<OgrenciAdresEkleModel, OgrenciAdres>();
            CreateMap<OgrenciMailEkleModel, OgrenciMail>();
            CreateMap<OgrenciTelefonEkleModel, OgrenciTelefon>();

            CreateMap<KitapHareket, OduncTabloModel>()
                .ForMember(d => d.KitapAdi, t => t.MapFrom(v => v.Kitap.Adi))
                .ForMember(d => d.KitapDurum, t => t.MapFrom(v => v.Kitap.KitapDurum))
                .ForMember(d => d.OgrenciAdi, t => t.MapFrom(v => v.Ogrenci.Ad + " " + v.Ogrenci.Soyad));
        }
    }
}