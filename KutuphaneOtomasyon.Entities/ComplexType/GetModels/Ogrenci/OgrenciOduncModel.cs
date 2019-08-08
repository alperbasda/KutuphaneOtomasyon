using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.GetModels.Ogrenci
{
    public class OgrenciOduncModel : ViewModel
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Numara { get; set; }

        public bool ElindeKitapVarmi { get; set; }
    }
}