using System.Linq;
using KutuphaneOtomasyon.Core.DataAccess.Concrete;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Core.EntityFramework;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciAdres;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciMail;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciTelefon;

namespace KutuphaneOtomasyon.DataAccess.Concrete
{
    public class OgrenciDal : RepositoryBase<Ogrenci, KutuphaneContext>, IOgrenciDal
    {
        public bool MailDuzenle(OgrenciMailEkleModel model)
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {
                //doğru yontem her tabloda bu şekilde olmalı ama okadar vaktim yok.
                //context.OgrenciMailler.Where(s => s.OgrenciId == model.OgrenciId && !s.Silindi);
                var mail = context.OgrenciMailler.FirstOrDefault(s => s.OgrenciId == model.OgrenciId);
                if (mail != null)
                    context.OgrenciMailler.Remove(mail);
                context.OgrenciMailler.Add(new OgrenciMail
                {
                    OgrenciId = model.OgrenciId,
                    MailAdresi = model.MailAdresi,
                });
                return context.SaveChanges()>0;

            }
        }

        public bool AdresDuzenle(OgrenciAdresEkleModel model)
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {

                var adres = context.OgrenciAdresler.FirstOrDefault(s => s.OgrenciId == model.OgrenciId && s.AdresTipi==model.AdresTipi);
                if (adres != null)
                    context.OgrenciAdresler.Remove(adres);
                context.OgrenciAdresler.Add(new OgrenciAdres
                {
                    OgrenciId = model.OgrenciId,
                    Adres = model.Adres,
                    AdresTipi = model.AdresTipi

                });
                return context.SaveChanges() > 0;

            }
        }

        public bool TelefonDuzenle(OgrenciTelefonEkleModel model)
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {

                var telefon = context.OgrenciTelefonlar.FirstOrDefault(s => s.OgrenciId == model.OgrenciId);
                if (telefon != null)
                    context.OgrenciTelefonlar.Remove(telefon);
                context.OgrenciTelefonlar.Add(new OgrenciTelefon
                {
                    OgrenciId = model.OgrenciId,
                    Telefon = model.Telefon,
                });
                return context.SaveChanges() > 0;

            }
        }
    }
}