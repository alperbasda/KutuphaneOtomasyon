using System;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.KitapAnahtari
{
    public partial class KitapAnahtariEkle : System.Web.UI.Page
    {
        [Inject]
        public IKitapAnahtarService KitapAnahtarService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void KitapAnahtarEkleButton_OnClick(object sender, EventArgs e)
        {
            
            var response = KitapAnahtarService.KitapAnahtarEkle(ObjectCreator.Create<KitapAnahtarEkleModel>(KitapAnahtarEkleForm));
            if (response.Tamamlandi)
                Response.Redirect("../KitapAnahtari/KitapAnahtariEkle.aspx?notificationSuccess=" + response.Mesaj);
            Response.Redirect("../KitapAnahtari/KitapAnahtariEkle.aspx?notificationError=" + response.Mesaj);
        }
    }
}