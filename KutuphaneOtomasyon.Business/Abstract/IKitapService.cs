using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapService
    {
        DataResponse KitapEkle(KitapEkleModel model);

        DataResponse KitapSeciciListele(KitapAraModel model=null);

        DataResponse KitaplariGetirTablo(KitapAraModel model);
    }
}