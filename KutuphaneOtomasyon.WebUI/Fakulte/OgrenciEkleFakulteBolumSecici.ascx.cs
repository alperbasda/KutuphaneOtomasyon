using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    public partial class OgrenciEkleFakulteBolumSecici : UserControl
    {
        [Inject]
        public IFakulteService FakulteService { private get; set; }

        [Inject]
        public IBolumService BolumService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FakulteleriDoldur(FakultelerGetir());
        }

        private List<FakulteModel> FakultelerGetir()
        {
            var response = FakulteService.FakulteleriGetir();
            if (response.Tamamlandi)
                return (List<FakulteModel>)response.Data;
            return null;
        }

        private void FakulteleriDoldur(List<FakulteModel> models)
        {
            if (models == null)
                FakulteId.Items.Add(new ListItem { Text = "Fakülteler yüklenemedi", Value = "null" });
            else
            {
                foreach (var item in models.OrderBy(s=>s.FakulteAdi))
                    FakulteId.Items.Add(new ListItem { Text = item.FakulteAdi, Value = item.Id.ToString() });
            }

        }

        protected void FakulteId_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                BolumId.Items.Clear();
                var response = BolumService.BolumleriGetir(new BolumAraModel
                { FakulteId = int.Parse(((DropDownList)sender).SelectedValue) });
                if (!response.Tamamlandi)
                    return;
                foreach (var item in ((List<BolumSeciciModel>)response.Data).OrderBy(s=>s.BolumAdi))
                {
                    BolumId.Items.Add(new ListItem { Text = item.BolumAdi, Value = item.Id.ToString() });
                }
                infoLabel.Text = "";
            }
            catch(Exception ex)
            {
                infoLabel.Text = "Bir hata oldu. Lütfen sayfayı yenileyin";
            }

        }
    }
}