using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapAnahtarService
    {
        DataResponse KitapAnahtarEkle(KitapAnahtarEkleModel model);
    }
}