using eDoc.Model.Common;
using eDoc.Model.Common.Enums;
using eDoc.Model.Common.Exceptions;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Repositories.Base
{
    public abstract class EfRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IDbEntity<TKey>
    {
        protected ApplicationContextBase Context { get; }
        protected bool PermanentDelete { get; }
        protected DbSet<TEntity> EntitySet { get; }
        public EfRepositoryBase(ApplicationContextBase applicationContext)
        {
            Context = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            PermanentDelete = Context.OnDelete == ContextDeleteOption.Permanent;
            EntitySet = Context.Set<TEntity>();
        }
        public virtual void Add(TEntity item)
        {
            item.CreationDate = DateTime.UtcNow;
            item.LastModifiedDate = DateTime.UtcNow;
            EntitySet.Add(item);
        }
        public virtual void Delete(TEntity item)
        {
            if (item == null)
                throw new EntityNotFoundException(typeof(TEntity).Name);

            if (PermanentDelete)
            {
                EntitySet.Remove(item);
                return;
            }
            item.IsDeleted = true;
            Update(item);
        }
        public virtual void Delete(TKey key)
        {
            var entity = EntitySet.Find(key);
            Delete(entity);
        }
        public virtual TEntity Get(TKey id)
        {
            return EntitySet.FirstOrDefault(i => !i.IsDeleted && i.Id.Equals(id));
        }
        public IQueryable<TEntity> GetAll()
        {
            return EntitySet.Where(i => !i.IsDeleted);
        }
        public virtual void Update(TEntity item)
        {
            item.LastModifiedDate = DateTime.UtcNow;
            Context.Entry<TEntity>(item).State = EntityState.Modified;
        }
        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, PagingParams pagingParams, Ordering<TEntity> ordering = null)
        {
            var set = GetAll()
                .Where(predicate)
                .OrderBy(i => i.Id)
                .Skip((pagingParams.Page - 1) * pagingParams.PerPage + pagingParams.Offset)
                .Take(pagingParams.Fetch);

            if (ordering != null)
                set = ordering.Apply(set);

            return set;
        }
    }
}
