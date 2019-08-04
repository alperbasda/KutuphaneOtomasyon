using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.Core.Entity.Concrete
{
    public abstract class FilterModel<T> : IPostModel, IFilterModel
        where T : class, IEntity, new()
    {
        public int Sayfa { get; set; }

        public abstract IQueryable<T> ExecuteQueryables(IQueryable<T> queryable);

        protected IQueryable<T> PageQueryable(IQueryable<T> queryable)
        {
            if (Sayfa == 0)
                Sayfa = 1;
            int skipCount = Sayfa * 10;
            return queryable.OrderBy(s => s.Id).Skip(skipCount).Take(10);
        }
    }
}