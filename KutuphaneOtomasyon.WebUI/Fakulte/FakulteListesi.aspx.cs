using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Fakulte
{
    public partial class FakulteListesi : PageBase
    {
        [Inject]
        public IFakulteService FakulteService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FakulteleriDoldur(FakultelerGetir());
        }

        private List<FakulteModel> FakultelerGetir()
        {

            var response = FakulteService.FakulteleriGetir(QueryStringHelper.QueryByName<FakulteAraModel>(Request.QueryString.ToString()));
            if (response.Tamamlandi)
                return (List<FakulteModel>)response.Data;
            return null;
        }

        private void FakulteleriDoldur(List<FakulteModel> models)
        {
            Fakulteler.DataSource = models.OrderBy(s => s.FakulteAdi);
            Fakulteler.DataBind();
        }


    }
}