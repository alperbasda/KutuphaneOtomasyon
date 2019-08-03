using System.Collections.Generic;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Fakulte : Entity
    {
        public string Adi { get; set; }

        public virtual ICollection<Bolum> FakultedekiBolumler { get; set; }

    }
}