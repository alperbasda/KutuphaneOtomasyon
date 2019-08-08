using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IBolumService
    {
        DataResponse BolumEkle(BolumEkleModel model);

        DataResponse BolumGetirId(int id);

        DataResponse BolumDuzenle(BolumDuzenleModel model);

        DataResponse BolumSil(int id);

        DataResponse BolumleriGetir(BolumAraModel model = null);

        DataResponse BolumleriGetirTablo(BolumAraModel model);
    }
}