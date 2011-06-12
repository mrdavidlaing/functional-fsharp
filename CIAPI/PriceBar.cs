using System;

namespace CIAPI
{
    public class PriceBar
    {
        public PriceBar(DateTime barDate, decimal open, decimal high, decimal low, decimal close)
        {
            BarDate = barDate;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public PriceBar()
        {
        }

        public DateTime BarDate { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }

        public override string ToString()
        {
            return string.Format("PriceBar at {0}", BarDate);
        }
    }
}