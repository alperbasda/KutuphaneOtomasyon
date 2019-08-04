using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class OgrenciTelefonMap : EntityTypeConfiguration<OgrenciTelefon>
    {
        public OgrenciTelefonMap()
        {
            ToTable("OgrenciTelefonlar", "Akinsoft");

            HasKey(s => s.Id);
            Property(s => s.Telefon).IsRequired().HasColumnType("nvarchar").HasMaxLength(11);
            Property(s => s.SonGuncelleme).IsOptional().HasColumnType("datetime");
            #region Relations

            HasRequired(s => s.Ogrenci)
                .WithMany(s => s.OgrencininTelefonlari)
                .HasForeignKey(s => s.OgrenciId);

            #endregion
        }
    }
}