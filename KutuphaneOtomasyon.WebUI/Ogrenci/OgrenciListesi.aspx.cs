using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Ogrenci
{
    public partial class OgrenciListesi : System.Web.UI.Page
    {

        [Inject]
        public IOgrenciService OgrenciService { private get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OgrencileriGetir();
                OgrencilerDoldur();
            }
        }

        private void OgrencileriGetir()
        {
            var response = OgrenciService.OgrenciGetirTablo(QueryStringHelper.QueryByName<OgrenciAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }
            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void OgrencilerDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            OgrenciListesiRepeater.DataSource = _pageModel.TabloData;
            OgrenciListesiRepeater.DataBind();
        }
    }

}