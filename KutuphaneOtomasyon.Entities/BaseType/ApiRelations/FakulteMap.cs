using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class FakulteMap : EntityTypeConfiguration<Fakulte>
    {
        public FakulteMap()
        {
            ToTable("Fakulteler","Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.Adi).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            
        }
    }
}