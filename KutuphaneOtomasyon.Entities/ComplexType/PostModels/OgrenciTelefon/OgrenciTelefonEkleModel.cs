using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciTelefon
{
    public class OgrenciTelefonEkleModel : PostModel
    {
        [Required(ErrorMessage = "Öğrenci seçimi yapılamadı")]
        public int OgrenciId { get; set; }

        [MaxLength(11, ErrorMessage = "Öğrenci telefonnu 11 haneli olmalı")]
        [MinLength(11, ErrorMessage = "Öğrenci telefonnu 11 haneli olmalı")]
        [Required(ErrorMessage = "Lütfen ögrenci telefonu girin")]
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
    }
}