using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Odunc;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapHareketService
    {
        DataResponse OduncGetirTablo(OduncAraModel model);

        DataResponse OduncEkle(int ogrenciId,int kitapId);

        DataResponse TeslimAl(int id);
    }
}