using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KitapMap : EntityTypeConfiguration<Kitap>
    {
        public KitapMap()
        {
            ToTable("Kitaplar", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Adi).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            HasKey(s => s.Id);
            Property(s => s.Kod).IsRequired().HasColumnType("nvarchar");
            Property(s => s.SonGuncelleme).IsOptional().HasColumnType("datetime");
            Property(s => s.ISBN).IsRequired().HasColumnType("nvarchar").HasMaxLength(13).HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute("IX_ISBN") { IsUnique = true }));
            Property(s => s.SayfaSayisi).IsRequired().HasColumnType("int");
            Property(s => s.YayinYili).IsRequired().HasColumnType("int");
            Property(s => s.Yazar).IsRequired().HasColumnType("nvarchar").HasMaxLength(150);
            //default kütüphanede
            //data annotation ile atanabilir fakat kod yönetimini tek yerden yürütmek en doğrusu.
            Property(s => s.KitapDurum).IsOptional();
            HasIndex(s => s.Adi);
            HasIndex(s => s.Yazar);

            #region Relations

            HasRequired(s => s.KitapKategori)
                .WithMany(s => s.KategoridekiKitaplar)
                .HasForeignKey(s => s.KitapKategoriId);

            #endregion

        }
    }
}