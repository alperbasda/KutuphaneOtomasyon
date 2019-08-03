using KutuphaneOtomasyon.Entities.Response.Abstract;

namespace KutuphaneOtomasyon.Entities.Response.Concrete
{
    public class DataResponse : IViewResponse
    {
        public bool Tamamlandi { get; set; }

        public string Mesaj { get; set; }

        public object Data { get; set; }
    }
}