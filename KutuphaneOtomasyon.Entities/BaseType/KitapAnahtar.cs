using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class KitapAnahtar : Entity
    {
        public string Anahtar { get; set; }

        public int KitapId { get; set; }

        public virtual Kitap Kitap { get; set; }
    }
}