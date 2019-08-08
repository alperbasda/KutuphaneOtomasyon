using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapAnahtarService
    {
        DataResponse KitapAnahtarEkle(KitapAnahtarEkleModel model);

        DataResponse KitapAnahtarGetirId(int id);

        DataResponse KitapAnahtarDuzenle(KitapAnahtarDuzenleModel model);

        DataResponse KitapAnahtarSil(int id);

        DataResponse KitapAnahtarGetirTablo(KitapAnahtarAraModel model);
    }
}