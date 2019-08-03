using System.Data.Entity;
using System.Linq;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.Core.DataAccess.Concrete
{
    public class QueryableRepositoryBase<T> : IQueryableRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        public QueryableRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entities;

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());


    }
}