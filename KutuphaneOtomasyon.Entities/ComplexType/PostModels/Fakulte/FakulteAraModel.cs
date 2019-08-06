using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte
{
    public class FakulteAraModel : FilterModel<BaseType.Fakulte>
    {
        public string FakulteAdi { get; set; }

        private IQueryable<BaseType.Fakulte> FakulteAdiQuery(IQueryable<BaseType.Fakulte> queryable)
        {
            if (!string.IsNullOrEmpty(FakulteAdi))
                return queryable.Where(s => s.Adi.ToLower().Contains(FakulteAdi.ToLower()));
            return queryable;
        }


        public override IQueryable<BaseType.Fakulte> ExecuteQueryables(IQueryable<BaseType.Fakulte> queryable)
        {

            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }

        public override int Count(IQueryable<BaseType.Fakulte> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            return queryable.Count();
        }

        protected override IQueryable<BaseType.Fakulte> WithoutPageExecuteQueryable(IQueryable<BaseType.Fakulte> queryable)
        {
            return FakulteAdiQuery(queryable);
        }
    }
}