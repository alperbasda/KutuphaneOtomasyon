using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            //schema farklı olsun ki izinleri kolayca set edelim
            ToTable("Loglar", "AkinsoftAdmin");
            HasKey(s => s.Id);

        }
    }
}