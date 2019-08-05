using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IFakulteService
    {
        DataResponse FakulteEkle(FakulteEkleModel model);

        DataResponse FakulteleriGetir(FakulteAraModel model=null);
    }
}