using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapKategoriService
    {
        DataResponse KitapKategoriEkle(KitapKategoriEkleModel model);

        DataResponse KitapKategoriGetir(KitapKategoriAraModel model = null);
    }
}