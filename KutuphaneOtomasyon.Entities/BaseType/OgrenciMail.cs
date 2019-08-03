using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class OgrenciMail : Entity
    {
        public string MailAdresi { get; set; }

        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}