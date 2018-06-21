using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Extensions
{
    public static class DateTimeExt
    {
        public static DateTime WithOffset(this DateTime original, int minutes)
        {
            return original.AddMinutes(minutes);
        }

        public static DateTime? WithOffset(this DateTime? original, int minutes)
        {
            return original.HasValue
                ? original.Value.WithOffset(minutes)
                : default(DateTime?);
        }
    }
}
