using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KitapKategoriMap : EntityTypeConfiguration<KitapKategori>
    {
        public KitapKategoriMap()
        {
            ToTable("KitapKategoriler", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Adi).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(s => s.SonGuncelleme).IsOptional().HasColumnType("datetime");

        }
    }
}