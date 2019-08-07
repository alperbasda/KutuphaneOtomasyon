using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.KitapAnahtari
{
    public partial class KitapAnahtariListesi : PageBase
    {
        [Inject]
        public IKitapAnahtarService KitapAnahtarService { get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitapAnahtarlariGetir();
                KitapAnahtarlariDoldur();
            }

        }

        private void KitapAnahtarlariGetir()
        {
            var response = KitapAnahtarService.KitapAnahtarGetirTablo(QueryStringHelper.QueryByName<KitapAnahtarAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }
            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void KitapAnahtarlariDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            KitapAnahtarListesiRepeater.DataSource = _pageModel.TabloData;
            KitapAnahtarListesiRepeater.DataBind();
        }
    }
}