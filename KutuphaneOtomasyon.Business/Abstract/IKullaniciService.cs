using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kullanici;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKullaniciService
    {
        DataResponse GirisYap(GirisModel model);
    }
}