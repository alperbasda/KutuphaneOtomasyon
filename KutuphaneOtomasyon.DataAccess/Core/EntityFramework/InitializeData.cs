using System;
using System.Data.Entity;
using KutuphaneOtomasyon.Entities.BaseType;

namespace KutuphaneOtomasyon.DataAccess.Core.EntityFramework
{
    public class InitializeData : CreateDatabaseIfNotExists<KutuphaneContext>
    {
        protected override void Seed(KutuphaneContext context)
        {
            //Kullanıcı Rolleri initialize ediliyor.
            context.Roller.Add(new Rol { RolAdi = "Admin",SonGuncelleme = DateTime.Now});
            var rol = context.Roller.Add(new Rol { RolAdi = "Kullanici" });
            context.SaveChanges();

            //Kullanıcılar initialize ediliyor.
            var kullanici = context.Kullanicilar.Add(new Kullanici { KullaniciAdi = "admin"});
            context.SaveChanges();

            //Kullanıcı Sifreleri initialize ediliyor.
            context.KullanicilarSifreler.Add(new KullaniciSifre { KullaniciId = kullanici.Id,Sifre = "hRVWDi6Yc6EbrRuPX/NN3Q==" });
            context.SaveChanges();

            //Kullanıcı Rol ataması yapılıyor.
            context.KullaniciRoller.Add(new KullaniciRol { KullaniciId = kullanici.Id, RolId = rol.Id });
            context.SaveChanges();
        }
    }
}