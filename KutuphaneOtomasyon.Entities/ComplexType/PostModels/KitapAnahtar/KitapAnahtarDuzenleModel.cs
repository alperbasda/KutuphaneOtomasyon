using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar
{
    public class KitapAnahtarDuzenleModel : EditModel
    {
        [Required(ErrorMessage = "Lütfen kitap anahtarı yazın")]
        [MaxLength(50, ErrorMessage = "Kitap anahtarı 5 ile 50 karakter arasında olmalı")]
        [MinLength(5, ErrorMessage = "Kitap anahtarı 5 ile 50 karakter arasında olmalı")]
        public string Anahtar { get; set; }

        [Required(ErrorMessage = "Lütfen kitap seçin")]
        public int KitapId { get; set; }

        public string KitapAd { get; set; }
    }
}