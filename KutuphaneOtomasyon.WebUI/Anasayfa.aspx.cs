using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.Response.Concrete;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI
{
    public partial class Anasayfa : PageBase
    {
        [Inject]
        public IViewService ViewService { private get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            DataResponse response = ViewService.SiteStatistics();
            if (!response.Tamamlandi)
                Response.Redirect("~/Giris/GirisYap.aspx?notificationError="+response.Mesaj);
            
        }

    }
}