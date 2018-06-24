using eDoc.Model.Common;
using eDoc.Model.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Repositories.Base
{
    public interface IRepository<TEntity, TKey> where TEntity : IDbEntity<TKey>
    {
        void Delete(TEntity item);
        void Delete(TKey key);
        void Update(TEntity item);
        void Add(TEntity item);
        TEntity Get(TKey id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, PagingParams pagingParams, Ordering<TEntity> ordering);
    }
}
