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
        public virtual void Delete(TEntity item)
        {
            EntitySet.Remove(item);
        }
        public virtual void Delete(TKey key)
        {
            var entity = EntitySet.Find(key);
            if (entity != null)
                EntitySet.Remove(entity);
        }
        public virtual TEntity Get(TKey id)
        {
            return EntitySet.Find(id);
        }
        public IQueryable<TEntity> GetAll()
        {
            return EntitySet;
        }
        public virtual void Update(TEntity item)
        {
            Context.Entry<TEntity>(item).State = EntityState.Modified;
        }
        public IQueryable<TEntity> GetMany(PagingParams pagingParams, Ordering<TEntity> ordering = null)
        {

             throw new NotImplementedException();
        }
    }
}
