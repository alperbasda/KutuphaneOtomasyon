using System;
using System.Collections.Generic;
using System.Linq;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Concrete;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapKategori;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.KitapKategori
{
    public partial class KitapKategoriListele : PageBase
    {
        [Inject]
        public IKitapKategoriService KitapKategoriService {private get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitapKategoriGetir();
                KitapKategoriDoldur();
            }
        }

        private void KitapKategoriGetir()
        {
            var response = KitapKategoriService.KitapKategoriGetirTablo(QueryStringHelper.QueryByName<KitapKategoriAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }
            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void KitapKategoriDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            KitapKategoriler.DataSource = (List<KitapKategoriModel>)_pageModel.TabloData;
            KitapKategoriler.DataBind();
        }
        
    }
}