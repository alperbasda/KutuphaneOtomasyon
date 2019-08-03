using System;
using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Kitap : Entity
    {
        public string Adi { get; set; }

        public string Kod { get; set; }

        public string Yazar { get; set; }

        public int YayinYili { get; set; }

        public string ISBN { get; set; }

        public bool BostaMi { get; set; }

        public int SayfaSayisi { get; set; }

        public int KitapKategoriId { get; set; }

        public virtual KitapKategori KitapKategori { get; set; }

        public virtual ICollection<KitapAnahtar> KitapAnahtarlari { get; set; }

        public virtual ICollection<KitapHareket> KitabinOgrencileri { get; set; }
        
    }
}