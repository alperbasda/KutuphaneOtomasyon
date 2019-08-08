using System.ComponentModel;

namespace KutuphaneOtomasyon.Entities.Enum
{
    public enum KitapDurumTeslim
    {
        [Description("Kitap Durumu Seçin")]
        SecimYapilmadi,
        [Description("Teslim Edildi")]
        TeslimEdildi,
        [Description("Teslim Edilmedi")]
        TeslimEdilmedi,
    }
}