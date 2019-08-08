using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Ogrenci
{
    public partial class OgrenciSil : System.Web.UI.Page
    {
        [Inject]
        public IOgrenciService Service { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = Service.OgrenciSil(id);
                if (response.Tamamlandi)
                    Response.Redirect("../Ogrenci/OgrenciListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../Ogrenci/OgrenciListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Ogrenci/OgrenciListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}