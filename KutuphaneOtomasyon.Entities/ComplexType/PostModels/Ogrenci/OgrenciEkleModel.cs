using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci
{
    public class OgrenciEkleModel : PostModel
    {
        [Required(ErrorMessage = "Lütfen ögrenci adını girin")]
        [MaxLength(100,ErrorMessage = "Ögrenci adı en fazla 100 karakter olabilir")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen ögrenci soyadını girin")]
        [MaxLength(100, ErrorMessage = "Öğrenci soyadı en fazla 100 karakter olabilir")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Lütfen ögrenci numarasını girin")]
        [MaxLength(50, ErrorMessage = "Öğrenci numarası en fazla 50 karakter olabilir")]
        public string Numara { get; set; }

        [MaxLength(1000, ErrorMessage = "Öğrenci memleket adresi en fazla 1000 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen ögrenci memleket adresi girin")]
        public string OgrenciMemleketAdres { get; set; }

        [MaxLength(1000, ErrorMessage = "Öğrenci adresi en fazla 1000 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen ögrenci adresi girin")]
        public string OgrenciAdres { get; set; }

        [MaxLength(100, ErrorMessage = "Öğrenci mail adresi en fazla 100 karakter olabilir")]
        [Required(ErrorMessage = "Lütfen ögrenci mail adresi girin")]
        [DataType(DataType.EmailAddress)]
        public string OgrenciMail { get; set; }

        [MaxLength(11, ErrorMessage = "Öğrenci telefonnu 11 haneli olmalı")]
        [MinLength(11, ErrorMessage = "Öğrenci telefonnu 11 haneli olmalı")]
        [Required(ErrorMessage = "Lütfen ögrenci telefonu girin")]
        [DataType(DataType.PhoneNumber)]
        public string OgrenciTelefon { get; set; }

        [Required(ErrorMessage = "Lütfen bölüm seçin")]
        public int BolumId { get; set; }
    }
}