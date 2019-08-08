using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using Ninject;
using Ninject.Web;

namespace KutuphaneOtomasyon.WebUI.Odunc
{
    public partial class OduncEkle : PageBase
    {
        [Inject]
        public IOgrenciService OgrenciService { private get; set; }

        [Inject]
        public IKitapService KitapService { private get; set; }

        [Inject]
        public IKitapHareketService KitapHareketService { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void AraButton_OnClick(object sender, EventArgs e)
        {
            if (Numara.Text.Length < 4)
            {
                return;
            }
            var response = OgrenciService.OgrenciGetirOduncTablo(new OgrenciAraModel { Numara = Numara.Text });
            if (response.Tamamlandi)
            {

                OgrenciRepeater.DataSource = response.Data;
                OgrenciRepeater.DataBind();
            }
        }

        protected void OgrenciAta_OnClick(object sender, EventArgs e)
        {

            SecilenOgrenci.Text = ((Button)sender).CommandName.Replace(',', ' ');
            OgrenciId.Text = ((Button)sender).CommandArgument;
            ogrenciBilgi.Update();
        }

        protected void KitapAraIsim_OnClick(object sender, EventArgs e)
        {
            if (KitapAdiTb.Text.Length < 4 && ISBNTb.Text.Length < 4)
            {
                return;
            }
            var response = KitapService.KitaplariGetirTablo(new KitapAraModel { KitapAdi = KitapAdiTb.Text, ISBN = ISBNTb.Text });
            if (response.Tamamlandi)
            {
                kitapRepeater.DataSource = ((PageModel)response.Data).TabloData;
                kitapRepeater.DataBind();
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            SecilenKitap.Text = ((Button)sender).CommandName.Replace(',', ' ');
            KitapId.Text = ((Button)sender).CommandArgument;
            kitapBilgi.Update();
        }

        protected void Kaydet_OnClick(object sender, EventArgs e)
        {
            int kit;
            int ogr;
            if (int.TryParse(KitapId.Text, out kit) && int.TryParse(OgrenciId.Text, out ogr))
            {
                var response = KitapHareketService.OduncEkle(ogr, kit);
                if (response.Tamamlandi)
                    Response.Redirect("../Odunc/OduncListesi.aspx?notificationSuccess="+response.Mesaj);
                Response.Redirect("../Odunc/OduncListesi.aspx?notificationError=" + response.Mesaj);
            }
            Response.Redirect("../Odunc/OduncEkle.aspx?notificationError=Hatalı Bilgi Girdiniz");


        }
    }
}