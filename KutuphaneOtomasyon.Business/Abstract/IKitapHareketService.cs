using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Odunc;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapHareketService
    {
        DataResponse OduncGetirTablo(OduncAraModel model);
    }
}