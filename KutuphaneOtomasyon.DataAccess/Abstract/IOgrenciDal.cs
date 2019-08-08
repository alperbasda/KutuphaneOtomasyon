using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciAdres;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciMail;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.OgrenciTelefon;

namespace KutuphaneOtomasyon.DataAccess.Abstract
{
    public interface IOgrenciDal : IRepositoryBase<Ogrenci>
    {
        bool MailDuzenle(OgrenciMailEkleModel model);

        bool AdresDuzenle(OgrenciAdresEkleModel model);

        bool TelefonDuzenle(OgrenciTelefonEkleModel model);
    }
}