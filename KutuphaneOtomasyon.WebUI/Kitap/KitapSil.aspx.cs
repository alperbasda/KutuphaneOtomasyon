using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Kitap
{
    public partial class KitapSil : System.Web.UI.Page
    {
        [Inject]
        public IKitapService Service { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = Service.KitapSil(id);
                if (response.Tamamlandi)
                    Response.Redirect("../Kitap/KitapListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../Kitap/KitapListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Kitap/KitapListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}