using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Business.Helpers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kullanici;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private IQueryableRepositoryBase<Kullanici> _queryable;
        public KullaniciManager(IQueryableRepositoryBase<Kullanici> queryable)
        {
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        public DataResponse GirisYap(GirisModel model)
        {
            var kullanici = KullaniciGetir(model);
            if (kullanici == null)
                return new DataResponse
                {
                    Tamamlandi = false,
                    Mesaj = "kullanıcı Adı veya şifre hatalı",
                };
            CreateTicket(kullanici);
            return new DataResponse
            {
                Mesaj = "Merhaba " + kullanici.KullaniciAdi.ToUpper() + " !!!",
                Tamamlandi = true,
            };
        }

        public DataResponse CikisYap()
        {
            FormsAuthentication.SignOut();
            if (HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName] != null)
                HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Çıkış yaptınız."
            };
        }


        private Kullanici KullaniciGetir(GirisModel model)
        {
            var pass = CryptoTool.EnCryptoPass(model.Sifre);
            IQueryable<Kullanici> query = _queryable.Table;
            return query.Include(s => s.KullaniciRolleri.Select(w => w.Rol)).FirstOrDefault(s =>
                s.KullaniciAdi == model.KullaniciAdi && s.KullaniciSifreleri.Any(e => e.Sifre == pass && !s.Silindi) && !s.Silindi);
        }


        private void CreateTicket(Kullanici kullanici)
        {
            AuthenticationHelper.CreateAuthCookie(kullanici.KullaniciAdi, kullanici.Id,
                kullanici.KullaniciRolleri.Select(s => s.Rol.RolAdi).ToArray());
        }
    }
}