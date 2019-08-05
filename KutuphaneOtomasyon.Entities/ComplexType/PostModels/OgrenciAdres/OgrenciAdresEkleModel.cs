using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciAdres
{
    public class OgrenciAdresEkleModel:PostModel
    {
        [Required(ErrorMessage = "Öğrenci seçimi yapılamadı")]
        public int OgrenciId { get; set; }

        [MaxLength(1000, ErrorMessage = "Öğrenci adresi en fazla 1000 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen ögrenci adresi girin")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Ögrenci adres tipi seçin")]
        public AdresTipi AdresTipi { get; set; }
    }
}