using System;

namespace PriceHistoryGenerators
{
    public class HistoryRequest
    {
        public HistoryRequest()
        {
            Interval = "undefined";
            SymbolId = "undefined";
        }

        public string SymbolId { get; set; }
        public string Interval { get; set; }
        public int NumberOfBars { get; set; }
    }
}