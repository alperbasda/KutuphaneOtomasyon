using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Odunc;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Odunc
{
    public partial class OduncListesi : PageBase
    {
        [Inject]
        public IKitapHareketService KitapHareketService { private get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OduncGetir();
                OduncDoldur();
            }
        }

        private void OduncGetir()
        {
            var response = KitapHareketService.OduncGetirTablo(QueryStringHelper.QueryByName<OduncAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }

            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void OduncDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            OduncListem.DataSource = _pageModel.TabloData;
            OduncListem.DataBind();
        }
    }
}