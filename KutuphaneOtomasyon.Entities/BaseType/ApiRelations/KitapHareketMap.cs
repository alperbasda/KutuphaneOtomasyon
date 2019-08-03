using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KitapHareketMap:EntityTypeConfiguration<KitapHareket>
    {
        public KitapHareketMap()
        {
            ToTable("KitapHareketler", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.AlinmaTarihi).IsOptional();
            Property(s => s.TeslimTarihi).IsOptional();
            Property(s => s.EsZamanli).IsOptional().IsConcurrencyToken();
            HasIndex(s => s.AlinmaTarihi);
            HasIndex(s => s.TeslimTarihi);

            #region Relations
            HasRequired(s => s.Kitap)
                .WithMany(s => s.KitabinOgrencileri)
                .HasForeignKey(ph => ph.KitapId);
            HasRequired(s => s.Ogrenci)
                .WithMany(s => s.OgrencininKitaplari)
                .HasForeignKey(ph => ph.OgrenciId);

            #endregion

        }
    }
}