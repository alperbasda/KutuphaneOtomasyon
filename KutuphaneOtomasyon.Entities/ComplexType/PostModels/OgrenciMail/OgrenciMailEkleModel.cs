using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciMail
{
    public class OgrenciMailEkleModel:PostModel
    {
        [Required(ErrorMessage = "Öğrenci seçimi yapılamadı")]
        public int OgrenciId { get; set; }

        [MaxLength(100, ErrorMessage = "Öğrenci mail adresi en fazla 100 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen ögrenci mail adresi girin")]
        [DataType(DataType.EmailAddress)]
        public string MailAdresi { get; set; }
    }
}