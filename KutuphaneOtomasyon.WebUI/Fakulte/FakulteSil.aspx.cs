using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    public partial class FakulteSil : System.Web.UI.Page
    {
        [Inject]
        public IFakulteService Service { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = Service.FakulteSil(id);
                if (response.Tamamlandi)
                    Response.Redirect("../Fakulte/FakulteListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../Fakulte/FakulteListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Fakulte/FakulteListesi.aspx?notificationError=Hatalı Bilgi Girdiniz");
        }
    }
}