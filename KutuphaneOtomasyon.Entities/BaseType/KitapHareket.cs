using System;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class KitapHareket : Entity
    {
        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }

        public int KitapId { get; set; }

        public virtual Kitap Kitap { get; set; }

        public DateTime? AlinmaTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }

    }
}