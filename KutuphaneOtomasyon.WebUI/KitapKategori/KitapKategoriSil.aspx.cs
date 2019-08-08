using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.KitapKategori
{
    public partial class KitapKategoriSil : System.Web.UI.Page
    {
        [Inject]
        public IKitapKategoriService Service { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = Service.KitapKategoriSil(id);
                if (response.Tamamlandi)
                    Response.Redirect("../KitapKategori/KitapKategoriListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../KitapKategori/KitapKategoriListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../KitapKategori/KitapKategoriListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}