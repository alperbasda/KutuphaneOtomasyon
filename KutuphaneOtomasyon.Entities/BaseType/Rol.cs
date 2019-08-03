using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Rol: Entity
    {
        public string RolAdi { get; set; }

        public virtual ICollection<KullaniciRol> RoldekiKullanicilar { get; set; }
    }
}