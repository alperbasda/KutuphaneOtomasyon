using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class KullaniciRol:Entity
    {
        public int KullaniciId { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }

    }
}