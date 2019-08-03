using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class OgrenciTelefon : Entity
    {
        public string Telefon { get; set; }

        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}