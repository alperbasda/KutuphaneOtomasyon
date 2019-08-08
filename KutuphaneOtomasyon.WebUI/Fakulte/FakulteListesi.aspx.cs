using System;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    public partial class FakulteListesi : PageBase
    {
        [Inject]
        public IFakulteService FakulteService { get; set; }

        private PageModel _pageModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FakultelerGetir();
                FakulteleriDoldur();
            }

        }

        private void FakultelerGetir()
        {
            var response = FakulteService.FakulteleriGetirTablo(QueryStringHelper.QueryByName<FakulteAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            if (response.Tamamlandi)
            {
                _pageModel = (PageModel)response.Data;
                return;
            }
            Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
        }

        private void FakulteleriDoldur()
        {
            sayfaSayisi.Text = _pageModel.ToplamSayfa.ToString();
            toplamData.Text = _pageModel.ToplamData.ToString();
            Fakulteler.DataSource = _pageModel.TabloData;
            Fakulteler.DataBind();
        }

        //protected void Sil_OnClick()
        //{
        //    int id;
        //    if (int.TryParse(((LinkButton)sender).Attributes["DataId"], out id))
        //    {
        //        var response = FakulteService.FakulteSil(id);
        //        if (response.Tamamlandi)
        //            Response.Redirect("../Fakulte/FakulteListesi.aspx?notificationSuccess=" + response.Mesaj);
        //        Response.Redirect("../Fakulte/FakulteListesi.aspx?notificationError=" + response.Mesaj);
        //    }
        //    Response.Redirect("../Anasayfa.aspx?notificationError=İşlem sırasında hata oluştu");
        //}
    }
}