using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapAnahtar
{
    public class KitapAnahtarTabloModel : ViewModel
    {
        public string Anahtar { get; set; }

        public int KitapId { get; set; }

        public string KitapAdi { get; set; }
    }
}