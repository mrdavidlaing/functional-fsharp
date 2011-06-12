using System;

namespace PriceHistoryGenerators
{
    public class Aug21TimeGenerator: TimeGenerator
    {
        public override DateTime GetNowUtc()
        {
            return new DateTime(2011, 8, 21);
        }
    }

    public class TimeGenerator
    {
        public virtual DateTime GetNowUtc()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetNowUtcWithoutSeconds()
        {
            return new DateTime(GetNowUtc().Year, GetNowUtc().Month, GetNowUtc().Day, 
                                GetNowUtc().Hour, GetNowUtc().Minute, 0);
        }

        public long GetSecondsSinceMidnight()
        {
            var ticksSinceMidnight = GetNowUtc().Ticks - (new DateTime(GetNowUtc().Year, GetNowUtc().Month, GetNowUtc().Day,0, 0, 0)).Ticks;
            return Convert.ToInt64(TimeSpan.FromTicks(ticksSinceMidnight).TotalSeconds);
        }

        public DateTime GetDayStart()
        {
            return new DateTime(GetNowUtc().Year, GetNowUtc().Month, GetNowUtc().Day,0, 0, 0);
        }
    }
}
