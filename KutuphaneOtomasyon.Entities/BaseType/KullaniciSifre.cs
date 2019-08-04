using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class KullaniciSifre : Entity
    {
        public string Sifre { get; set; }

        public int KullaniciId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}