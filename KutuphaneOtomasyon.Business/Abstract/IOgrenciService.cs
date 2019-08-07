using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Abstract
{
    public interface IOgrenciService
    {
        DataResponse OgrenciEkle(OgrenciEkleModel model);

        DataResponse OgrenciGetirTablo(OgrenciAraModel model);
    }
}