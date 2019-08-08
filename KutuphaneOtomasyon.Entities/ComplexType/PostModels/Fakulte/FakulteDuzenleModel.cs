using System.ComponentModel.DataAnnotations;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte
{
    public class FakulteDuzenleModel: EditModel
    {
        [Required(ErrorMessage = "Fakülte adını girin")]
        [MaxLength(100, ErrorMessage = "Fakülte adı 100 karakterden uzun olamaz")]
        public string FakulteAdi { get; set; }
    }
}