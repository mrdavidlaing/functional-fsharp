using System.Collections.Generic;
using Newtonsoft.Json;
using PriceHistoryGenerators;

namespace CIAPI
{
    public static class CIAPI
    {
        private static string markets = @"[{""MarketId"":400520618,""Name"":""US Crude Oil Aug 11 Spread""},{""MarketId"":400516270,""Name"":""GBP\/USD (per 0.0001) Dec 11 CFD""},{""MarketId"":400509815,""Name"":""UK 100 Aug 11 Spread""}]";
        private static string priceHistory400520618 = @"";
        private static string priceHistory400516270 = @"";
        private static string priceHistory400509815 = @"";
        
        public static Market[] GetMarkets()
        {
            return JsonConvert.DeserializeObject<Market[]>(markets);
        }

        public static List<PriceBar> GetPriceHistory(int marketId, int numberOfBars)
        {
            var gen = new SinPriceHistoryGenerator();
            return gen.GeneratePrices(new HistoryRequest
                                   {Interval = "MINUTE", NumberOfBars = numberOfBars, SymbolId = marketId.ToString()});
            
        }
    }
}
