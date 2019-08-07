using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Bolum
{
    public partial class BolumListesi : PageBase
    {
        [Inject]
        public IBolumService BolumService { get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BolumGetir();
                BolumDoldur();
            }

        }

        private void BolumGetir()
        {
            var response = BolumService.BolumleriGetirTablo(QueryStringHelper.QueryByName<BolumAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }

            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void BolumDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            Bolumler.DataSource = _pageModel.TabloData;
            Bolumler.DataBind();
        }
    }
}