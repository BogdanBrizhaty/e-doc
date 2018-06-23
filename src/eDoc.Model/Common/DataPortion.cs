using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Common
{
    public sealed class DataPortion<TItem>
    {
        public int TotalCount { get; }
        public int TotalPages { get; }
        public IEnumerable<TItem> Items { get; }

        public DataPortion(IEnumerable<TItem> items, int amount)
        {
            Items = items;
            TotalCount = amount;
        }
        public DataPortion(IEnumerable<TItem> items, int amount, int perPage)
            :this(items, amount)
        {
            TotalPages = (int)Math.Ceiling((double)amount / perPage);
        }
    }
}
