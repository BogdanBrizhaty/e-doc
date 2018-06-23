using eDoc.Model.Common;
using eDoc.Model.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Repositories.Base
{
    public abstract class EfRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected ApplicationContextBase Context { get; }
        protected DbSet<TEntity> EntitySet { get; }
        public EfRepositoryBase(ApplicationContextBase applicationContext)
        {
            Context = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            EntitySet = Context.Set<TEntity>();
        }
        public virtual void Add(TEntity item)
        {
            EntitySet.Add(item);
        }
        public virtual void Delete(TEntity item) => throw new NotImplementedException();
        public virtual void Delete(TKey key) => throw new NotImplementedException();
        public virtual TEntity Get(TKey id) => throw new NotImplementedException();
        public IQueryable<TEntity> GetAll() => throw new NotImplementedException();
        public virtual void Update(TEntity item) => throw new NotImplementedException();
        public IQueryable<TEntity> GetMany(PagingParams pagingParams, Ordering<TEntity> ordering) => throw new NotImplementedException();
    }
}
