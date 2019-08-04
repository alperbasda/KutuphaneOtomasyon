using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum
{
    public class BolumEkleModel : PostModel
    {
        [Required(ErrorMessage = "Lütfen fakülte seçin")]
        public int FakulteId { get; set; }

        [Required(ErrorMessage = "Lütfen bölüm adını yazın")]
        [MaxLength(100,ErrorMessage = "Bölüm adı en fazla 100 karakter olabilir")]
        public string BolumAdi { get; set; }
    }
}