using System;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Ogrenci
{
    public partial class OgrenciEkle : PageBase
    {
        [Inject]
        public IOgrenciService OgrenciService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OgrenciEkleButton_OnClick(object sender, EventArgs e)
        {
            var response = OgrenciService.OgrenciEkle(ObjectCreator.Create<OgrenciEkleModel>(OgrenciEkleForm));
            if (response.Tamamlandi)
                Response.Redirect("../Ogrenci/OgrenciEkle?notificationSuccess=" + response.Mesaj);
            Response.Redirect("../Ogrenci/OgrenciEkle?notificationError=" + response.Mesaj);
        }
    }
}