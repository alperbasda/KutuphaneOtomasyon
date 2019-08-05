using System;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI
{
    public partial class Cikis : PageBase
    {
        [Inject]
        public IKullaniciService KullaniciService { private get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Giris/GirisYap.aspx?notificationSuccess=" + KullaniciService.CikisYap().Mesaj);
        }
    }
}