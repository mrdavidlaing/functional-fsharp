using System.Collections.Generic;
using Newtonsoft.Json;
using PriceHistoryGenerators;

namespace CIAPI
{
    public static class CIAPI
    {
        private const string markets = @"[{""MarketId"":400520618,""Name"":""US Crude Oil""},{""MarketId"":400516270,""Name"":""GBP\/USD""},{""MarketId"":400509815,""Name"":""UK 100""}]";
        
        public static Market[] GetMarkets()
        {
            return JsonConvert.DeserializeObject<Market[]>(markets);
        }

        public static PriceBar[] GetPriceHistory(int marketId, int numberOfBars)
        {
            return new SinPriceHistoryGenerator()
                .GeneratePrices(new HistoryRequest
                                   {
                                       Interval = "MINUTE", 
                                       NumberOfBars = numberOfBars, 
                                       SymbolId = marketId.ToString()
                                   })
                .ToArray();
        }
    }
}
