using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Odunc
{
    public partial class TeslimAl : System.Web.UI.Page
    {

        [Inject]
        public IKitapHareketService KitapHareketService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = KitapHareketService.TeslimAl(id);
                if (response.Tamamlandi)
                    Response.Redirect("../Odunc/OduncListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../Odunc/OduncListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Odunc/OduncListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}