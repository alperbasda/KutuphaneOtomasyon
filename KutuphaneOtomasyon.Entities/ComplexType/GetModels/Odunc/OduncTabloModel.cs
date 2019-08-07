using System;
using KutuphaneOtomasyon.Core.Entity.Concrete;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Entities.ComplexType.GetModels.Odunc
{
    public class OduncTabloModel : ViewModel
    {
        public int KitapId { get; set; }

        public int OgrenciId { get; set; }

        public string KitapAdi { get; set; }

        public string OgrenciAdi { get; set; }

        public DateTime AlinmaTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }

        public KitapDurum KitapDurum { get; set; }

    }
}