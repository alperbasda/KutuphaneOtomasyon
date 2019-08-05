using System;
using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Ogrenci : Entity
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Numara { get; set; }

        public DateTime? KayitTarihi { get; set; }

        public int BolumId { get; set; }

        public virtual Bolum Bolum { get; set; }

        public virtual ICollection<KitapHareket> OgrencininKitaplari { get; set; }

        public virtual ICollection<OgrenciAdres> OgrencininAdresleri { get; set; }

        public virtual ICollection<OgrenciMail> OgrencininMailAdresleri { get; set; }

        public virtual ICollection<OgrenciTelefon> OgrencininTelefonlari { get; set; }
    }
}