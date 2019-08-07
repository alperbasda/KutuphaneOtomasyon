using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci
{
    public class OgrenciAraModel: FilterModel<BaseType.Ogrenci>
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Numara { get; set; }

        public int BolumId { get; set; }

        private IQueryable<BaseType.Ogrenci> AdQuery(IQueryable<BaseType.Ogrenci> queryable)
        {
            if (!string.IsNullOrEmpty(Ad))
                return queryable.Where(s => s.Ad.Trim().ToLower().Contains(Ad.Trim().ToLower()));
            return queryable;
        }

        private IQueryable<BaseType.Ogrenci> SoyadQuery(IQueryable<BaseType.Ogrenci> queryable)
        {
            if (!string.IsNullOrEmpty(Soyad))
                return queryable.Where(s => s.Soyad.Trim().ToLower().Contains(Soyad.Trim().ToLower()));
            return queryable;
        }

        private IQueryable<BaseType.Ogrenci> NumaraQuery(IQueryable<BaseType.Ogrenci> queryable)
        {
            if (!string.IsNullOrEmpty(Numara))
                return queryable.Where(s => s.Numara.Trim().Contains(Numara.Trim()));
            return queryable;
        }

        private IQueryable<BaseType.Ogrenci> BolumQuery(IQueryable<BaseType.Ogrenci> queryable)
        {
            if (BolumId !=0)
                return queryable.Where(s => s.BolumId==BolumId);
            return queryable;
        }

        public override IQueryable<BaseType.Ogrenci> ExecuteQueryables(IQueryable<BaseType.Ogrenci> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }

        protected override IQueryable<BaseType.Ogrenci> WithoutPageExecuteQueryable(IQueryable<BaseType.Ogrenci> queryable)
        {
            queryable = AdQuery(queryable);
            queryable = SoyadQuery(queryable);
            queryable = NumaraQuery(queryable);
            queryable = BolumQuery(queryable);
            return queryable;
        }
    }
}