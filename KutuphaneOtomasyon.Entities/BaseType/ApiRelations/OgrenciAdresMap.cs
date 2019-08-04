using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class OgrenciAdresMap : EntityTypeConfiguration<OgrenciAdres>
    {
        public OgrenciAdresMap()
        {
            ToTable("OgrenciAdresler", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Adres).IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            Property(s => s.AdresTipi).IsRequired().HasColumnType("int");
            Property(s => s.SonGuncelleme).IsOptional().HasColumnType("datetime");
            #region Relations

            HasRequired(s => s.Ogrenci)
                .WithMany(s => s.OgrencininAdresleri)
                .HasForeignKey(s => s.OgrenciId);

            #endregion

        }
    }
}