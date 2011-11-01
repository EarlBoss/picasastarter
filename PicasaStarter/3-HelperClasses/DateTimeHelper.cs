using System;
using System.Collections.Generic;
using System.Text;

namespace HelperClasses
{
    class DateTimeHelper
    {
        /// <summary>
        /// Takes a DateTime value and rounds it to second precision (instead of "tick" precision).
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns>The DateTime rounded to second precision.</returns>
        public static DateTime RoundToSecondPrecision(DateTime dateTimeValue)
        {
            return new DateTime((long)Math.Round((Double)dateTimeValue.Ticks / (TimeSpan.TicksPerSecond)));
        }
    }
}
