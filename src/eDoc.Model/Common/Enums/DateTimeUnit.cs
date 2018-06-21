using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Common.Enums
{
    public enum DateTimeUnit
    {
        Minute = 1,
        Hour = 60,
        Day = 24 * Hour,
        Week = 7 * Day,
    }

    public static class DateTimeUnitExt
    {
        public static int ToMinutes(this DateTimeUnit unit, int number)
        {
            return (int)unit * number;
        }
    }
}
