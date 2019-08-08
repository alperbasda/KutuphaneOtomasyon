using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.KitapKategori
{
    public partial class KitapKategoriDuzenle : PageBase
    {
        [Inject]
        public IKitapKategoriService KitapKategoriService { get; set; }

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

        private KitapKategoriDuzenleModel Getir()
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = KitapKategoriService.KitapKategoriGetirId(id);
                if (response.Tamamlandi)
                    return (KitapKategoriDuzenleModel)response.Data;

                Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
            }
            else
                Response.Redirect("../Anasayfa.aspx?notificationError=İşlem sırasında hata oluştu.");

            return null;
        }




        protected void DuzenleButton_OnClick(object sender, EventArgs e)
        {
            var editModel = ObjectCreator.Create<KitapKategoriDuzenleModel>(form);
            var response = KitapKategoriService.KitapKategoriDuzenle(editModel);
            if (response.Tamamlandi)
                Response.Redirect($"~/KitapKategori/KitapKategoriDuzenle.aspx?Id={editModel.Id}&notificationSuccess=" + response.Mesaj);
            Response.Redirect($"~/KitapKategori/KitapKategoriDuzenle.aspx?Id={editModel.Id}&notificationError=" + response.Mesaj);
        }
    }
}