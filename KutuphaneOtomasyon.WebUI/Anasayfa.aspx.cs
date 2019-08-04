using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels;
using KutuphaneOtomasyon.Entities.Response.Concrete;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI
{
    public partial class Anasayfa : PageBase
    {
        [Inject]
        public IViewService ViewService { get; set; }

        private SiteStats _stats;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataResponse response = ViewService.SiteStatistics();
            if (!response.Tamamlandi)
                Response.Redirect("Giris.aspx");
            else
                _stats = response.Data as SiteStats;
        }

    }
}