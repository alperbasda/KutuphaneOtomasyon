using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Bolum
{
    public partial class BolumDuzenle : PageBase
    {
        [Inject]
        public IBolumService BolumService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Doldur();
            }
        }

        private void Doldur()
        {
            FormCreator.FillForm(form, Getir());
        }

        private BolumDuzenleModel Getir()
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = BolumService.BolumGetirId(id);
                if (response.Tamamlandi)
                    return (BolumDuzenleModel)response.Data;

                Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
            }
            else
                Response.Redirect("../Anasayfa.aspx?notificationError=İşlem sırasında hata oluştu.");

            return null;
        }




        protected void DuzenleButton_OnClick(object sender, EventArgs e)
        {
            var editModel = ObjectCreator.Create<BolumDuzenleModel>(form);
            var response = BolumService.BolumDuzenle(editModel);
            if (response.Tamamlandi)
                Response.Redirect($"~/Bolum/BolumDuzenle.aspx?Id={editModel.Id}&notificationSuccess=" + response.Mesaj);
            Response.Redirect($"~/Bolum/BolumDuzenle.aspx?Id={editModel.Id}&notificationError=" + response.Mesaj);
        }
    }
}