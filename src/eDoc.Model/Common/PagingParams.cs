using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Common
{
    public class PagingParams
    {
        public int Page { get; }
        public int PerPage { get; }
        public int Fetch { get; }
        public int Offset { get; }

        public PagingParams(int page, int perPage)
            :this(page, perPage, perPage)
        {
        }
        public PagingParams(int page, int perPage, int fetch)
            :this(page, perPage, fetch, 0)
        {
        }
        public PagingParams(int page, int perPage, int fetch, int offset)
        {
            if (page < 1 || perPage < 1 || fetch < 1 || offset < 1)
                throw new ArgumentOutOfRangeException();

            if (offset > fetch - 1)
                throw new ArgumentException("Offset and Fetch are not valid");

            Page = page;
            PerPage = perPage;
            Fetch = fetch;
            Offset = offset;
        }
    }
}
