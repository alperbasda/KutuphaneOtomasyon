using KutuphaneOtomasyon.Core.Entity.Concrete;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class OgrenciAdres : Entity
    {
        public string Adres { get; set; }

        public AdresTipi AdresTipi { get; set; }

        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
        
    }
}