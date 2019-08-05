using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Kitap
{
    public partial class KitapEkle : PageBase
    {
        [Inject]
        public IKitapService KitapService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ObjectCreator.Create<KitapEkleModel>()
        }


        protected void KitapEkleButton_OnClick(object sender, EventArgs e)
        {
            var response = KitapService.KitapEkle(ObjectCreator.Create<KitapEkleModel>(KitapEkleForm));
            if(response.Tamamlandi)
                Response.Redirect("~/Kitap/KitapEkle.aspx?notificationSuccess="+response.Mesaj);
            Response.Redirect("~/Kitap/KitapEkle.aspx?notificationError=" + response.Mesaj);
        }
    }
}