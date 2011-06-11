using System;
using System.Collections.Generic;
using CIAPI;

namespace PriceHistoryGenerators
{
    public class SinPriceHistoryGenerator
    {
        private readonly TimeGenerator _timeGenerator;

        public SinPriceHistoryGenerator()
        {
            _timeGenerator = new TimeGenerator();
        }

        public SinPriceHistoryGenerator(TimeGenerator timeGenerator)
        {
            _timeGenerator = timeGenerator;
        }

        public List<PriceBar> GeneratePrices(HistoryRequest request)
        {
            var priceBars = new List<PriceBar>();

            long currentSecsSinceMidnight = _timeGenerator.GetSecondsSinceMidnight();
            for (int i = 0; i < request.NumberOfBars; i++)
            {
                long start = currentSecsSinceMidnight - (i * GetIntervalInSeconds(request.Interval));
                long end = start + GetIntervalInSeconds(request.Interval);
                priceBars.Insert(0, GeneratePriceBar(start, end));
            }

            return priceBars;
        }

        private PriceBar GeneratePriceBar(long startSecsSinceMidnight, long endSecsSinceMidnight)
        {
            var priceBar = new PriceBar
                               {
                                   BarDate = _timeGenerator.GetDayStart().AddSeconds(startSecsSinceMidnight),
                                   Open = GetMidPrice(startSecsSinceMidnight),
                                   Low = Decimal.MaxValue
                               };

            for (long s = startSecsSinceMidnight; s < endSecsSinceMidnight; s += 10)
            {
                decimal midPrice = GetMidPrice(s);
                if (priceBar.High < midPrice)
                {
                    priceBar.High = midPrice;
                }
                if (priceBar.Low > midPrice)
                {
                    priceBar.Low = midPrice;
                }
            }

            priceBar.Close = GetMidPrice(endSecsSinceMidnight);
            return priceBar;
        }

        public decimal GetMidPrice(long secsSinceMidnight)
        {
            decimal minSinceMidnight = Convert.ToDecimal(secsSinceMidnight/60.0m);
            decimal hoursSinceMidnight = Convert.ToDecimal(minSinceMidnight/60.0m);
            return Convert.ToDecimal(200 +
                   (Math.Sin(secsSinceMidnight)
                    + Math.Sin(Convert.ToDouble(minSinceMidnight)*10)
                    + Math.Sin(Convert.ToDouble(hoursSinceMidnight) * 100)));
        }

        public long GetIntervalInSeconds(string interval)
        {
            if (interval.ToLower() == "minute")
                return 60;

            if (interval.ToLower() == "day")
                return 60*60*24;

            if (interval.ToLower() == "week")
                return 60*60*24*7;

            throw new ArgumentException(string.Format("Unknown interval type. {0}", interval));
        }
    }
}