using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kullanici;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI
{
    public partial class Giris : PageBase
    {
        [Inject]
        public IKullaniciService KullaniciService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            var response = KullaniciService.GirisYap(ObjectCreator.Create<GirisModel>(girisForm));
            if (response.Tamamlandi)
                Response.Redirect("Anasayfa.aspx?notificationSuccess=" + response.Mesaj);
            Response.Redirect("Giris.aspx?notificationError=" + response.Mesaj);
        }
    }
}