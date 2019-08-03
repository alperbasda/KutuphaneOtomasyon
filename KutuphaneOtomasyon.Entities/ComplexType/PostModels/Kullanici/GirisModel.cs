using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kullanici
{
    public class GirisModel : PostModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı girin")]
        [MaxLength(20, ErrorMessage = "Kullanıcı adınız 20 karakterden uzun olamaz")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        [MaxLength(20,ErrorMessage = "Şifreniz 20 karakterden uzun olamaz")]
        public string Sifre { get; set; }
    }
}