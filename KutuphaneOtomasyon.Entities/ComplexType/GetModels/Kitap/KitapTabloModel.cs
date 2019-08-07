using KutuphaneOtomasyon.Core.Entity.Concrete;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Entities.ComplexType.GetModels.Kitap
{
    public class KitapTabloModel : ViewModel
    {
        public string Adi { get; set; }

        public string Kod { get; set; }

        public string Yazar { get; set; }

        public int YayinYili { get; set; }

        public string ISBN { get; set; }

        public KitapDurum KitapDurum { get; set; }

        public int SayfaSayisi { get; set; }

        public int KitapKategoriId { get; set; }

        public string KitapKategoriAdi { get; set; }
    }
}