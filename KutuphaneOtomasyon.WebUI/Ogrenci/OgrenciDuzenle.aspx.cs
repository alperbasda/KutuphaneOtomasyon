using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Ogrenci
{
    public partial class OgrenciDuzenle : PageBase
    {
        [Inject]
        public IOgrenciService OgrenciService { get; set; }

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

        private OgrenciDuzenleModel Getir()
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = OgrenciService.OgrenciGetirId(id);
                if (response.Tamamlandi)
                    return (OgrenciDuzenleModel)response.Data;

                Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
            }
            else
                Response.Redirect("../Anasayfa.aspx?notificationError=İşlem sırasında hata oluştu.");

            return null;
        }




        protected void DuzenleButton_OnClick(object sender, EventArgs e)
        {
            var editModel = ObjectCreator.Create<OgrenciDuzenleModel>(form);
            var response = OgrenciService.OgrenciDuzenle(editModel);
            if (response.Tamamlandi)
                Response.Redirect($"~/Ogrenci/OgrenciDuzenle.aspx?Id={editModel.Id}&notificationSuccess=" + response.Mesaj);
            Response.Redirect($"~/Ogrenci/OgrenciDuzenle.aspx?Id={editModel.Id}&notificationError=" + response.Mesaj);
        }
    }
}