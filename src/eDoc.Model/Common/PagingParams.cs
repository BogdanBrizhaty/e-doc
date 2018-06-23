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
    }
}
