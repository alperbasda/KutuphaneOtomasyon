using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class KitapKategori : Entity 
    {
        public string Adi { get; set; }

        public virtual ICollection<Kitap> KategoridekiKitaplar { get; set; }
    }
}