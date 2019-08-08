using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.KitapAnahtari
{
    public partial class KitapAnahtariDuzenle : PageBase
    {
        [Inject]
        public IKitapAnahtarService KitapAnahtarService { get; set; }

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

        private KitapAnahtarDuzenleModel Getir()
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = KitapAnahtarService.KitapAnahtarGetirId(id);
                if (response.Tamamlandi)
                    return (KitapAnahtarDuzenleModel)response.Data;

                Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
            }
            else
                Response.Redirect("../Anasayfa.aspx?notificationError=İşlem sırasında hata oluştu.");

            return null;
        }




        protected void DuzenleButton_OnClick(object sender, EventArgs e)
        {
            var editModel = ObjectCreator.Create<KitapAnahtarDuzenleModel>(form);
            var response = KitapAnahtarService.KitapAnahtarDuzenle(editModel);
            if (response.Tamamlandi)
                Response.Redirect($"~/KitapAnahtari/KitapAnahtariDuzenle.aspx?Id={editModel.Id}&notificationSuccess=" + response.Mesaj);
            Response.Redirect($"~/KitapAnahtari/KitapAnahtariDuzenle.aspx?Id={editModel.Id}&notificationError=" + response.Mesaj);
        }
    }
}