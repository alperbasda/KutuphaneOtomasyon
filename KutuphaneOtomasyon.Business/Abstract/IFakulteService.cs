using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IFakulteService
    {
        DataResponse FakulteEkle(FakulteEkleModel model);

        DataResponse FakulteGetirId(int id);

        DataResponse FakulteDuzenle(FakulteDuzenleModel model);

        DataResponse FakulteSil(int id);

        DataResponse FakulteleriGetir(FakulteAraModel model=null);

        DataResponse FakulteleriGetirTablo(FakulteAraModel model);
    }
}