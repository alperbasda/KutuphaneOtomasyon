using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    
    public partial class FakulteEkle : PageBase
    {
        [Inject]
        public IFakulteService FakulteService {private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FakulteKaydetButton_OnClick(object sender, EventArgs e)
        {
            var response = FakulteService.FakulteEkle(ObjectCreator.Create<FakulteEkleModel>(fakulteForm));
            if(response.Tamamlandi)
                Response.Redirect("~/Fakulte/FakulteEkle.aspx?notificationSuccess="+response.Mesaj);
            Response.Redirect("~/Fakulte/FakulteEkle.aspx?notificationError=" + response.Mesaj);
        }
    }
}