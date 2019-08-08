using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Bolum
{
    public partial class BolumSil : System.Web.UI.Page
    {
        [Inject]
        public IBolumService Service { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = Service.BolumSil(id);
                if (response.Tamamlandi)
                    Response.Redirect("../Bolum/BolumListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../Bolum/BolumListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Bolum/BolumListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}