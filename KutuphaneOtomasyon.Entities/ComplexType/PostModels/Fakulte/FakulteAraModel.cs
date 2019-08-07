using System;
using System.Configuration;
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
                return queryable.Where(s => s.Adi.ToLower().Trim().Contains(FakulteAdi.ToLower().Trim()));
            return queryable;
        }


        public override IQueryable<BaseType.Fakulte> ExecuteQueryables(IQueryable<BaseType.Fakulte> queryable)
        {

            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }
        

        protected override IQueryable<BaseType.Fakulte> WithoutPageExecuteQueryable(IQueryable<BaseType.Fakulte> queryable)
        {
            return FakulteAdiQuery(queryable);
        }
    }
}