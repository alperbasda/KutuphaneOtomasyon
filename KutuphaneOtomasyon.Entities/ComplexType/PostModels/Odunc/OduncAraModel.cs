using System;
using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Odunc
{
    public class OduncAraModel : FilterModel<KitapHareket>
    {
        public string KitapAdi { get; set; }

        public string OgrenciAdSoyad { get; set; }

        public DateTime? AlinmaTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }

        public KitapDurum KitapDurum { get; set; }

        public KitapDurumTeslim KitapDurumTeslim { get; set; }

        private IQueryable<KitapHareket> KitapQuery(IQueryable<KitapHareket> queryable)
        {
            if (!string.IsNullOrEmpty(KitapAdi))
                return queryable.Where(s =>
                    s.Kitap.Adi.ToLower().Trim().Contains(KitapAdi.ToLower().Trim()) ||
                    s.Kitap.KitapAnahtarlari.Any(w => w.Anahtar.ToLower().Trim().Contains(KitapAdi)));
            return queryable;
        }
        private IQueryable<KitapHareket> OgrenciAdSoyadQuery(IQueryable<KitapHareket> queryable)
        {
            if (!string.IsNullOrEmpty(OgrenciAdSoyad))
            {
                var dizi = AdSoyadGetir();
                var ad = dizi[0];
                var sAd = dizi[1];
                queryable = queryable.Where(s => s.Ogrenci.Ad.ToLower().Trim().Contains(ad.Trim().ToLower()));
                if (!string.IsNullOrEmpty(sAd))
                    queryable = queryable.Where(s => s.Ogrenci.Soyad.ToLower().Trim().Contains(sAd.Trim().ToLower()));
                return queryable;
            }
            return queryable;
        }

        private IQueryable<KitapHareket> AlinmaTarihiQuery(IQueryable<KitapHareket> queryable)
        {
            if (AlinmaTarihi != null && AlinmaTarihi != DateTime.MinValue)
                return queryable.Where(s => s.AlinmaTarihi == AlinmaTarihi);
            return queryable;
        }

        private IQueryable<KitapHareket> TeslimTarihiQuery(IQueryable<KitapHareket> queryable)
        {
            if (TeslimTarihi != null && TeslimTarihi != DateTime.MinValue)
                return queryable.Where(s => s.TeslimTarihi == TeslimTarihi);
            return queryable;
        }

        private IQueryable<KitapHareket> KitapDurumQuery(IQueryable<KitapHareket> queryable)
        {
            if (KitapDurum != KitapDurum.SecimYapilmadi)
                return queryable.Where(s => s.Kitap.KitapDurum == KitapDurum);
            return queryable;
        }

        private IQueryable<KitapHareket> KitapDurumTeslimQuery(IQueryable<KitapHareket> queryable)
        {
            if (KitapDurumTeslim == KitapDurumTeslim.TeslimEdilmedi)
                return queryable.Where(s => s.TeslimTarihi ==null);
            if (KitapDurumTeslim == KitapDurumTeslim.TeslimEdildi)
                return queryable.Where(s => s.TeslimTarihi != null);
            return queryable;
        }

        public override IQueryable<KitapHareket> ExecuteQueryables(IQueryable<KitapHareket> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }

        protected override IQueryable<KitapHareket> WithoutPageExecuteQueryable(IQueryable<KitapHareket> queryable)
        {
            queryable = KitapQuery(queryable);
            queryable = OgrenciAdSoyadQuery(queryable);
            queryable = AlinmaTarihiQuery(queryable);
            queryable = TeslimTarihiQuery(queryable);
            queryable = KitapDurumQuery(queryable);
            queryable = KitapDurumTeslimQuery(queryable);
            return queryable;
        }

        private string[] AdSoyadGetir()
        {
            string[] dizi = new string[2];
            var adSoyad = OgrenciAdSoyad.Trim().Split(' ');
            dizi[0] = adSoyad.Length < 2 ? adSoyad[0] : string.Join(" ", adSoyad.Take(adSoyad.Count() - 1));
            dizi[1] = adSoyad.Length >= 2 ? adSoyad.Last() : "";
            return dizi;
        }
    }
}