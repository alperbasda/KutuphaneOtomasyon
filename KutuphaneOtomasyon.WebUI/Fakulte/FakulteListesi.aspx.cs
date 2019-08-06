using System;
using System.Collections.Generic;
using System.Linq;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
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

        private PageModel FakultelerGetir()
        {

            var response = FakulteService.FakulteleriGetirTablo(QueryStringHelper.QueryByName<FakulteAraModel>(Server.UrlDecode(Request.QueryString.ToString())));
            return (PageModel)response.Data;

        }

        private void FakulteleriDoldur(PageModel model)
        {
            sayfaSayisi.Text = model.TotalPage.ToString();
            toplamData.Text = model.TotalData.ToString();
            if (model.TableData != null)
            {
                Fakulteler.DataSource = ((List<FakulteModel>)model.TableData).OrderBy(s => s.FakulteAdi);
                Fakulteler.DataBind();
            }

        }

    }
}