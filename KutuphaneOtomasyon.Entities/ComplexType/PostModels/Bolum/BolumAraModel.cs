using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum
{
    public class BolumAraModel : FilterModel<BaseType.Bolum>
    {
        public string BolumAdi { get; set; }

        public string FakulteAdi { get; set; }

        public int FakulteId { get; set; }

        private IQueryable<BaseType.Bolum> BolumAdiQuery(IQueryable<BaseType.Bolum> queryable)
        {
            if (!string.IsNullOrEmpty(BolumAdi))
                return queryable.Where(s => s.Adi.ToLower().Contains(BolumAdi));
            return queryable;
        }

        private IQueryable<BaseType.Bolum> FakulteAdiQuery(IQueryable<BaseType.Bolum> queryable)
        {
            if (!string.IsNullOrEmpty(FakulteAdi))
                return queryable.Where(s => s.Fakulte.Adi.ToLower().Contains(FakulteAdi));
            return queryable;
        }

        private IQueryable<BaseType.Bolum> FakulteIdQuery(IQueryable<BaseType.Bolum> queryable)
        {
            if (FakulteId != 0)
                return queryable.Where(s => s.FakulteId == FakulteId);
            return queryable;
        }

        public override IQueryable<BaseType.Bolum> ExecuteQueryables(IQueryable<BaseType.Bolum> queryable)
        {
            queryable = FakulteIdQuery(queryable);
            queryable = BolumAdiQuery(queryable);
            queryable = FakulteAdiQuery(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }
    }
}