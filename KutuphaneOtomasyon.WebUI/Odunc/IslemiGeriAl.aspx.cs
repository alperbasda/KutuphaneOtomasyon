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
    public partial class IslemiGeriAl : System.Web.UI.Page
    {
        [Inject]
        public IKitapHareketService KitapHareketService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var response = KitapHareketService.GeriAl();
                if(response.Tamamlandi)
                    Response.Redirect("../Odunc/OduncListesi.aspx?notificationSuccess=" + response.Mesaj);
                Response.Redirect("../Odunc/OduncListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Odunc/OduncListesi.aspx");
        }
        
    }
}