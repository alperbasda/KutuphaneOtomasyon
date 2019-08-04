using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class RolMap : EntityTypeConfiguration<Rol>
    {
        public RolMap()
        {
            ToTable("Roller", "Akinsoft");
            HasKey(s => s.Id);
            Property(s => s.RolAdi).IsRequired().HasColumnType("nvarchar").HasMaxLength(10);
            Property(s => s.SonGuncelleme).IsOptional().HasColumnType("datetime");

        }
    }
}