namespace KutuphaneOtomasyon.Entities.ComplexType.PageModels
{
    public class PageModel 
    {
        public object TableData { get; set; }

        public int TotalPage { get; set; }

        public int TotalData { get; set; }

        public int CurrentPage { get; set; }
    }
}