using System;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    public partial class FakulteDuzenle : PageBase
    {
        [Inject]
        public IFakulteService FakulteService { get; set; }

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

        private FakulteDuzenleModel Getir()
        {
            int id;
            if (int.TryParse(Request.QueryString["Id"], out id))
            {
                var response = FakulteService.FakulteGetirId(id);
                if (response.Tamamlandi)
                    return (FakulteDuzenleModel)response.Data;

                Response.Redirect("../Anasayfa.aspx?notificationError=" + response.Mesaj);
            }
            else
                Response.Redirect("../Anasayfa.aspx?notificationError=İşlem sırasında hata oluştu.");

            return null;
        }

        


        protected void DuzenleButton_OnClick(object sender, EventArgs e)
        {
            var editModel = ObjectCreator.Create<FakulteDuzenleModel>(form);
            var response = FakulteService.FakulteDuzenle(editModel);
            if (response.Tamamlandi)
                Response.Redirect($"~/Fakulte/FakulteDuzenle.aspx?Id={editModel.Id}&notificationSuccess=" + response.Mesaj);
            Response.Redirect($"~/Fakulte/FakulteDuzenle.aspx?Id={editModel.Id}&notificationError=" + response.Mesaj);
        }
    }
}