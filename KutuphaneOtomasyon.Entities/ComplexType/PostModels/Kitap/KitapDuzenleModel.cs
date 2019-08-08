using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap
{
    public class KitapDuzenleModel : EditModel
    {
        [Required(ErrorMessage = "Lütfen kitap adı girin")]
        [MaxLength(200, ErrorMessage = "Kitap adı en fazla 200 karakter olabilir")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Lütfen kodu girin")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Lütfen yazarı girin")]
        [MaxLength(150, ErrorMessage = "Yazar adı en fazla 150 karakter olabilir")]
        public string Yazar { get; set; }

        [Required(ErrorMessage = "Lütfen yayın yılı girin")]
        [Range(1100, 2100, ErrorMessage = "1100 ile 2100 arasında bir değer girmelisiniz")]
        public int YayinYili { get; set; }

        [Required(ErrorMessage = "Lütfen ISBN girin")]
        [MaxLength(13, ErrorMessage = "ISBN numarası 13 haneli olmalı")]
        [MinLength(13, ErrorMessage = "ISBN numarası 13 haneli olmalı")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Lütfen sayfa sayısı girin")]
        [Range(1, int.MaxValue, ErrorMessage = "Sayfa sayısı 0 dan büyük olmalı")]
        public int SayfaSayisi { get; set; }

        [Required(ErrorMessage = "Lütfen kitap kategorisi seçin")]
        public int KitapKategoriId { get; set; }
    }
}