using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Common
{
    /// <summary>
    /// Provides sorting in ascending and descending orders for entities
    /// </summary>
    /// <typeparam name="T">Any</typeparam>
    public class Ordering<T>
    {
        private readonly Func<IQueryable<T>, IOrderedQueryable<T>> _transform;

        private Ordering(Func<IQueryable<T>, IOrderedQueryable<T>> transform) => _transform = transform;

        public static Ordering<T> Create<TKey>
            (Expression<Func<T, TKey>> primary)
        {
            return new Ordering<T>(query => query.OrderBy(primary));
        }

        public Ordering<T> ThenBy<TKey>(Expression<Func<T, TKey>> secondary)
        {
            return new Ordering<T>(query => _transform(query).ThenBy(secondary));
        }
        public static Ordering<T> CreateDesc<TKey>
            (Expression<Func<T, TKey>> primary)
        {
            return new Ordering<T>(query => query.OrderByDescending(primary));
        }

        public Ordering<T> ThenDescendingBy<TKey>(Expression<Func<T, TKey>> secondary)
        {
            return new Ordering<T>(query => _transform(query).ThenByDescending(secondary));
        }

        public IOrderedQueryable<T> Apply(IQueryable<T> query)
        {
            return _transform(query);
        }
    }
}
