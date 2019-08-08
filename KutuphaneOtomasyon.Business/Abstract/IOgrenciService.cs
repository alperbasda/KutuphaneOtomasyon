using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IOgrenciService
    {
        DataResponse OgrenciEkle(OgrenciEkleModel model);

        DataResponse OgrenciGetirId(int id);

        DataResponse OgrenciDuzenle(OgrenciDuzenleModel model);

        DataResponse OgrenciSil(int id);

        DataResponse OgrenciGetirTablo(OgrenciAraModel model);

        DataResponse OgrenciGetirOduncTablo(OgrenciAraModel model);
    }
}