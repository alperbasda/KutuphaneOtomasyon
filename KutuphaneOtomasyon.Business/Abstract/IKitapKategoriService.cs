using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IKitapKategoriService
    {
        DataResponse KitapKategoriEkle(KitapKategoriEkleModel model);

        DataResponse KitapKategoriGetirId(int id);

        DataResponse KitapKategoriDuzenle(KitapKategoriDuzenleModel model);

        DataResponse KitapKategoriSil(int id);

        DataResponse KitapKategoriGetir(KitapKategoriAraModel model = null);

        DataResponse KitapKategoriGetirTablo(KitapKategoriAraModel model);
    }
}