using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori
{
    public class KitapKategoriEkleModel:PostModel
    {
        [Required(ErrorMessage = "Lütfen kategori adı girin")]
        [MaxLength(200,ErrorMessage = "Kategori adı en fazla 200 karakter olmalı")]
        public string KitapKategoriAdi { get; set; }

    }
}