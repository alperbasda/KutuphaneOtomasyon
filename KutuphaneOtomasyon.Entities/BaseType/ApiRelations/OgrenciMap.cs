using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class OgrenciMap : EntityTypeConfiguration<Ogrenci>
    {
        public OgrenciMap()
        {
            ToTable("Ogrenciler", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Ad).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(s => s.Soyad).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(s => s.KayitTarihi).IsOptional().HasColumnType("datetime");
            Property(s => s.Numara).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            
            #region Relations

            HasRequired(s => s.Bolum)
                .WithMany(s => s.BolumdekiOgrenciler)
                .HasForeignKey(s => s.BolumId);
            HasIndex(s => s.Ad);
            HasIndex(s => s.Soyad);
            HasIndex(s => s.Numara);



            #endregion
        }
    }
}