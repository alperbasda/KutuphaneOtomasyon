using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapKategori;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.KitapKategori
{
    public partial class KitapKategoriSecici : System.Web.UI.UserControl
    {
        [Inject]
        public IKitapKategoriService KitapKategoriService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                KitapKategorileriDoldur(KitapKategoriGetir());
        }

        private List<KitapKategoriModel> KitapKategoriGetir()
        {
            var response = KitapKategoriService.KitapKategoriGetir();
            if (response.Tamamlandi)
                return (List<KitapKategoriModel>)response.Data;
            return null;
        }

        private void KitapKategorileriDoldur(List<KitapKategoriModel> models)
        {
            if (models == null)
                KitapKategoriId.Items.Add(new ListItem { Text = "Kitap Kategorileri yüklenemedi", Value = "null" });
            else
            {
                foreach (var item in models)
                    KitapKategoriId.Items.Add(new ListItem { Text = item.KitapKategoriAdi, Value = item.Id.ToString() });
            }

        }
    }
}