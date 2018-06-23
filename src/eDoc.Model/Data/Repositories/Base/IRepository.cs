using eDoc.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Repositories.Base
{
    public interface IRepository<TItem, TKey>
    {
        void Delete(TItem item);
        void Delete(TKey key);
        void Update(TItem item);
        void Add(TItem item);
        TItem Get(TKey id);
        IQueryable<TItem> GetAll();
        IQueryable<TItem> GetMany(PagingParams pagingParams, Ordering<TItem> ordering);
    }
}
