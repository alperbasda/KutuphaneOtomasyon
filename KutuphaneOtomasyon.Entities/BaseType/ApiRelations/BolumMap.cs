using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class BolumMap : EntityTypeConfiguration<Bolum>
    {
        public BolumMap()
        {
            ToTable("Bolumler", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Adi).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            HasIndex(s => s.Adi);

            #region Relations

            HasRequired(s => s.Fakulte)
                .WithMany(s => s.FakultedekiBolumler)
                .HasForeignKey(s => s.FakulteId);

            #endregion


        }
    }
}