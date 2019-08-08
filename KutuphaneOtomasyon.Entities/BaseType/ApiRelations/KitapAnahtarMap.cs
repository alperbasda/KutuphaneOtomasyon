using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KitapAnahtarMap:EntityTypeConfiguration<KitapAnahtar>
    {
        public KitapAnahtarMap()
        {
            ToTable("KitapAnahtarlar", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Anahtar).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            

            #region Relations

            HasRequired(s => s.Kitap)
                .WithMany(s => s.KitapAnahtarlari)
                .HasForeignKey(s => s.KitapId);
            HasIndex(s => s.Anahtar);

            #endregion

        }
    }
}