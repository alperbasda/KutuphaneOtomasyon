﻿using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.Core.DataAccess.Abstract
{
    public interface IQueryableRepositoryBase<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}