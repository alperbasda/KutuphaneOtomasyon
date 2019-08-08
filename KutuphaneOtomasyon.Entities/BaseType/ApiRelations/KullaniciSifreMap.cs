using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KullaniciSifreMap:EntityTypeConfiguration<KullaniciSifre>
    {
        public KullaniciSifreMap()
        {
            ToTable("KullaniciSifre", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Sifre).IsRequired().HasColumnType("nvarchar");
            
            
            #region Relations

            HasRequired(s => s.Kullanici)
                .WithMany(s => s.KullaniciSifreleri)
                .HasForeignKey(s => s.KullaniciId);

            #endregion
        }
    }
}