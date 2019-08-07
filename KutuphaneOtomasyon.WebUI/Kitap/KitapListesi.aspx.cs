using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Kitap
{
    public partial class KitapListele : PageBase
    {
        [Inject]
        public IKitapService KitapService { get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitapGetir();
                KitapDoldur();
            }
        }

        private void KitapGetir()
        {
            var response = KitapService.KitaplariGetirTablo(QueryStringHelper.QueryByName<KitapAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }

            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void KitapDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            kitapRepeater.DataSource = _pageModel.TabloData;
            kitapRepeater.DataBind();
        }
    }
}