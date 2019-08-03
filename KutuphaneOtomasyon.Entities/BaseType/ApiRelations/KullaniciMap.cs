using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KullaniciMap: EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMap()
        {
            ToTable("Kullanicilar", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.KullaniciAdi).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(s => s.Sifre).IsRequired().HasColumnType("nvarchar");
            
        }

    }
}