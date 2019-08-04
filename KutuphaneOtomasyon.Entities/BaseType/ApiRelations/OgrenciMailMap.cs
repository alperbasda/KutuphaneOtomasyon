using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class OgrenciMailMap : EntityTypeConfiguration<OgrenciMail>
    {
        public OgrenciMailMap()
        {
            ToTable("OgrenciMailler", "Akinsoft");

            HasKey(s => s.Id);
            Property(s => s.MailAdresi).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(s => s.SonGuncelleme).IsOptional().HasColumnType("datetime");
            #region Relations

            HasRequired(s => s.Ogrenci)
                .WithMany(s => s.OgrencininMailAdresleri)
                .HasForeignKey(s => s.OgrenciId);

            #endregion
        }
    }
}