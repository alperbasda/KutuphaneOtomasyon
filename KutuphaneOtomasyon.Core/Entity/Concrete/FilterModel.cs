using System;
using System.Configuration;
using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.Core.Entity.Concrete
{
    public abstract class FilterModel<T> : IPostModel, IFilterModel
        where T : class, IEntity, new()
    {
        private int _sayfa;

        public int Sayfa
        {
            get => _sayfa <= 0 ? 1 : _sayfa;
            set => _sayfa = value <= 0 ? 1 : value;
        }

        public abstract IQueryable<T> ExecuteQueryables(IQueryable<T> queryable);

        protected abstract IQueryable<T> WithoutPageExecuteQueryable(IQueryable<T> queryable);

        public int Count(IQueryable<T> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            return queryable.Count();
        }

        public int PageCount(int toplamData)
        {
            return (int)Math.Ceiling((decimal)toplamData /
                                            Convert.ToInt32(ConfigurationManager.AppSettings["DataPerPage"]));
        }

        protected IQueryable<T> PageQueryable(IQueryable<T> queryable)
        {
            int skipCount = (Sayfa - 1) * 10;
            return queryable.OrderBy(s => s.Id).Skip(skipCount).Take(10);
        }
    }
}