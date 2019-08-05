using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    public partial class FakulteSecici : UserControl
    {
        [Inject]
        public IFakulteService FakulteService { private get; set; }

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
    }
}