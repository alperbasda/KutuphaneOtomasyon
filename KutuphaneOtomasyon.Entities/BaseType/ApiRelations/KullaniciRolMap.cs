using System.Data.Entity.ModelConfiguration;

namespace KutuphaneOtomasyon.Entities.BaseType.ApiRelations
{
    public class KullaniciRolMap : EntityTypeConfiguration<KullaniciRol>
    {
        public KullaniciRolMap()
        {
            ToTable("KullaniciRoller", "Akinsoft");
            HasKey(s => s.Id);

            #region Relations
            HasRequired(s=>s.Kullanici)
                .WithMany(s=>s.KullaniciRolleri)
                .HasForeignKey(ph => ph.KullaniciId);
            HasRequired(s => s.Rol)
                .WithMany(s => s.RoldekiKullanicilar)
                .HasForeignKey(ph => ph.RolId);

            #endregion

        }
    }
}