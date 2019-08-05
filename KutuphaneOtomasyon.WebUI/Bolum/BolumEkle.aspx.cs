using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Bolum
{
    public partial class BolumEkle : PageBase
    {
        [Inject]
        public IBolumService BolumService {private get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BolumEkleButton_OnClick(object sender, EventArgs e)
        {
           var response = BolumService.BolumEkle(ObjectCreator.Create<BolumEkleModel>(BolumForm));
           if(response.Tamamlandi)
               Response.Redirect("../Bolum/BolumEkle.aspx?notificationSuccess="+response.Mesaj);
           Response.Redirect("../Bolum/BolumEkle.aspx?notificationError=" + response.Mesaj);
        }
    }
}