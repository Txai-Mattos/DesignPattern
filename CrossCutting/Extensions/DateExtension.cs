using System;

namespace DesignPatternSamples.CrossCutting.Extensions
{
    public static class DateExtension
    {
        public static int GetQuarter(this DateTime date)
            => date.Month switch
            {
                < 4 => 1,
                < 7 => 2,
                < 10 => 3,
                _ => 4,
            };
    }
}
