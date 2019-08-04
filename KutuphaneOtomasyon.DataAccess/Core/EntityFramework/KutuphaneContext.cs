using System.Data.Entity;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.BaseType.ApiRelations;

namespace KutuphaneOtomasyon.DataAccess.Core.EntityFramework
{
    public class KutuphaneContext :DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<KullaniciSifre> KullanicilarSifreler { get; set; }

        public DbSet<Rol> Roller { get; set; }

        public DbSet<KullaniciRol> KullaniciRoller { get; set; }

        public DbSet<Log> Loglar { get; set; }

        public DbSet<Fakulte> Fakulteler { get; set; }

        public DbSet<Bolum> Bolumler { get; set; }

        public DbSet<KitapKategori> KitapKategoriler { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<KitapAnahtar> KitapAnahtarlar { get; set; }

        public DbSet<KitapHareket> KitapHareketler { get; set; }

        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<OgrenciAdres> OgrenciAdresler { get; set; }

        public DbSet<OgrenciMail> OgrenciMailler { get; set; }

        public DbSet<OgrenciTelefon> OgrenciTelefonlar { get; set; }

        public KutuphaneContext()
            :base("AkinsoftKutuphane")
        {
            
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new KullaniciMap());
            modelBuilder.Configurations.Add(new KullaniciSifreMap());
            modelBuilder.Configurations.Add(new KullaniciRolMap());
            modelBuilder.Configurations.Add(new FakulteMap());
            modelBuilder.Configurations.Add(new BolumMap());
            modelBuilder.Configurations.Add(new KitapKategoriMap());
            modelBuilder.Configurations.Add(new KitapMap());
            modelBuilder.Configurations.Add(new KitapAnahtarMap());
            modelBuilder.Configurations.Add(new KitapHareketMap());
            modelBuilder.Configurations.Add(new OgrenciMap());
            modelBuilder.Configurations.Add(new OgrenciAdresMap());
            modelBuilder.Configurations.Add(new OgrenciMailMap());
            modelBuilder.Configurations.Add(new OgrenciTelefonMap());
            modelBuilder.Configurations.Add(new LogMap());
        }
    }
}