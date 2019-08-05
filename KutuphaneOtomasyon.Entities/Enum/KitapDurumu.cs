using System.ComponentModel;

namespace KutuphaneOtomasyon.Entities.Enum
{
    public enum KitapDurum{
        [Description("Durum Seçin")]
        SecimYapilmadi,
        [Description("Kütüphanede")]
        Kutuphane,
        [Description("Ögrencide")]
        Ogrenci,
    }
}