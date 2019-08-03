using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Bolum : Entity
    {
        public string Adi { get; set; }

        public int FakulteId { get; set; }

        public virtual Fakulte Fakulte { get; set; }

        public virtual ICollection<Ogrenci> BolumdekiOgrenciler { get; set; }

    }
}