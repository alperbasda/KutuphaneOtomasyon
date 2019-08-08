using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.KitapAnahtari
{
    public partial class KitapAnahtariSil : System.Web.UI.Page
    {
        [Inject]
        public IKitapAnahtarService Service { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = Service.KitapAnahtarSil(id);
                if (response.Tamamlandi)
                    Response.Redirect("../KitapAnahtari/KitapAnahtariListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../KitapAnahtari/KitapAnahtariListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../KitapAnahtari/KitapAnahtariListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}