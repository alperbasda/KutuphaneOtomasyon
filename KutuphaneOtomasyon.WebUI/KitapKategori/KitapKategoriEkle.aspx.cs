using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.KitapKategori
{
    public partial class KitapKategoriEkle : PageBase
    {
        [Inject]
        public IKitapKategoriService KitapKategoriService { private get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void KitapKategoriEkleButton_OnClick(object sender, EventArgs e)
        {
            var response = KitapKategoriService.KitapKategoriEkle(ObjectCreator.Create<KitapKategoriEkleModel>(KitapKategoriEkleForm));
            if(response.Tamamlandi)
                Response.Redirect("../KitapKategori/KitapKategoriEkle.aspx?notificationSuccess="+response.Mesaj);
            Response.Redirect("../KitapKategori/KitapKategoriEkle.aspx?notificationError=" + response.Mesaj);
        }
    }
}