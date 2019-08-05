using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Kitap;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using Ninject;

namespace KutuphaneOtomasyon.WebUI.Kitap
{
    public partial class KitapSecici : UserControl
    {
        [Inject]
        public IKitapService KitapService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            searchLabel.Text = "Lütfen arama yapın";
        }


        protected void KitaplariGetir_OnClick(object sender, EventArgs e)
        {
            KitapId.Items.Clear();
            if (KitapAdi.Text.Length < 3)
            {
                searchLabel.Text = "Arama için en az 3 karakter girmelisiniz";
                return;
            }

            var response = KitapService.KitapSeciciListele(new KitapAraModel { KitapAdi = KitapAdi.Text });
            if (response.Tamamlandi)
            {
                var datas = (List<KitapSeciciModel>)response.Data;
                searchLabel.Text = datas.Count > 0 ? "" : "Kitap Bulunamadı";
                foreach (var item in datas)
                {
                    KitapId.Items.Add(new ListItem { Text = item.KitapAdi, Value = item.Id.ToString() });
                }
                return;
            }
            searchLabel.Text = response.Mesaj;


        }
    }
}