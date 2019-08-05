using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.WebUI.Helpers;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Bolum
{
    public partial class BolumListesi : PageBase
    {
        [Inject]
        public IBolumService BolumService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BolumDoldur(BolumGetir());
                    
        }
      
        private List<BolumTabloModel> BolumGetir()
        {

            var response = BolumService.BolumleriGetirTablo(QueryStringHelper.QueryByName<BolumAraModel>(Request.QueryString.ToString()));
            if (response.Tamamlandi)
                return (List<BolumTabloModel>)response.Data;
            return null;
        }

        private void BolumDoldur(List<BolumTabloModel> models)
        {
            Bolumler.DataSource = models.OrderBy(s => s.BolumAdi);
            Bolumler.DataBind();
        }
    }
}