using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Kullanici : Entity
    {
        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public virtual ICollection<KullaniciRol> KullaniciRolleri { get; set; }
    }
}