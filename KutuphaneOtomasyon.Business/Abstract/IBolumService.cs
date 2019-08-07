using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IBolumService
    {
        DataResponse BolumEkle(BolumEkleModel model);

        DataResponse BolumleriGetir(BolumAraModel model = null);

        DataResponse BolumleriGetirTablo(BolumAraModel model);
    }
}