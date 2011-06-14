using System.Linq;
using Newtonsoft.Json;
using PriceHistoryGenerators;

namespace CIAPI
{
    public static class CIAPI
    {
        private const string markets = @"[{""MarketId"":400520618,""Name"":""US Crude Oil""},{""MarketId"":400516270,""Name"":""GBP\/USD""},{""MarketId"":400509815,""Name"":""UK 100""}]";
        private const string uk100bars = @"[{""BarDate"":""\/Date(1307968980000)\/"",""Close"":5792.1,""High"":5792.1,""Low"":5792.0,""Open"":5792.0},{""BarDate"":""\/Date(1307969040000)\/"",""Close"":5792.0,""High"":5793.0,""Low"":5791.8,""Open"":5791.8},{""BarDate"":""\/Date(1307969100000)\/"",""Close"":5791.8,""High"":5792.8,""Low"":5791.8,""Open"":5791.8},{""BarDate"":""\/Date(1307969160000)\/"",""Close"":5790.8,""High"":5791.8,""Low"":5789.3,""Open"":5791.5},{""BarDate"":""\/Date(1307969220000)\/"",""Close"":5791.0,""High"":5791.8,""Low"":5790.8,""Open"":5790.8},{""BarDate"":""\/Date(1307969280000)\/"",""Close"":5790.5,""High"":5791.3,""Low"":5789.8,""Open"":5791.3},{""BarDate"":""\/Date(1307969340000)\/"",""Close"":5790.3,""High"":5791.0,""Low"":5789.8,""Open"":5790.8},{""BarDate"":""\/Date(1307969400000)\/"",""Close"":5791.3,""High"":5791.3,""Low"":5790.0,""Open"":5790.0},{""BarDate"":""\/Date(1307969460000)\/"",""Close"":5791.0,""High"":5791.3,""Low"":5789.8,""Open"":5790.5},{""BarDate"":""\/Date(1307969520000)\/"",""Close"":5790.3,""High"":5790.3,""Low"":5790.3,""Open"":5790.3},{""BarDate"":""\/Date(1307969580000)\/"",""Close"":5790.5,""High"":5790.8,""Low"":5790.3,""Open"":5790.5},{""BarDate"":""\/Date(1307969640000)\/"",""Close"":5791.3,""High"":5791.3,""Low"":5789.8,""Open"":5789.8},{""BarDate"":""\/Date(1307969700000)\/"",""Close"":5790.5,""High"":5791.5,""Low"":5790.5,""Open"":5791.5},{""BarDate"":""\/Date(1307969760000)\/"",""Close"":5791.5,""High"":5791.8,""Low"":5790.8,""Open"":5790.8},{""BarDate"":""\/Date(1307969820000)\/"",""Close"":5794.0,""High"":5794.3,""Low"":5791.3,""Open"":5791.3},{""BarDate"":""\/Date(1307969880000)\/"",""Close"":5802.8,""High"":5803.5,""Low"":5792.3,""Open"":5793.5},{""BarDate"":""\/Date(1307969940000)\/"",""Close"":5852.5,""High"":5852.6,""Low"":5801.8,""Open"":5802.3},{""BarDate"":""\/Date(1307970000000)\/"",""Close"":5903.0,""High"":5904.3,""Low"":5852.3,""Open"":5852.5},{""BarDate"":""\/Date(1307970060000)\/"",""Close"":6092.8,""High"":6093.3,""Low"":6091.8,""Open"":6093.3},{""BarDate"":""\/Date(1307970120000)\/"",""Close"":6091.5,""High"":6092.3,""Low"":6090.3,""Open"":6092.3},{""BarDate"":""\/Date(1307970180000)\/"",""Close"":6091.5,""High"":6091.8,""Low"":6090.3,""Open"":6091.8},{""BarDate"":""\/Date(1307970240000)\/"",""Close"":6090.5,""High"":6091.5,""Low"":6090.3,""Open"":6091.3},{""BarDate"":""\/Date(1307970300000)\/"",""Close"":6089.8,""High"":6090.3,""Low"":6088.8,""Open"":6090.0},{""BarDate"":""\/Date(1307970360000)\/"",""Close"":6088.5,""High"":6089.5,""Low"":6088.3,""Open"":6089.5},{""BarDate"":""\/Date(1307970420000)\/"",""Close"":6089.8,""High"":6089.8,""Low"":6088.8,""Open"":6088.8},{""BarDate"":""\/Date(1307970480000)\/"",""Close"":6090.0,""High"":6091.5,""Low"":6089.8,""Open"":6090.3},{""BarDate"":""\/Date(1307970540000)\/"",""Close"":6089.0,""High"":6089.5,""Low"":6089.0,""Open"":6089.3},{""BarDate"":""\/Date(1307970600000)\/"",""Close"":6089.8,""High"":6090.3,""Low"":6088.8,""Open"":6088.8},{""BarDate"":""\/Date(1307970660000)\/"",""Close"":6089.0,""High"":6089.8,""Low"":6088.5,""Open"":6089.3},{""BarDate"":""\/Date(1307970720000)\/"",""Close"":6088.8,""High"":6089.3,""Low"":6088.3,""Open"":6088.3},{""BarDate"":""\/Date(1307970780000)\/"",""Close"":6088.8,""High"":6089.3,""Low"":6088.5,""Open"":6089.0},{""BarDate"":""\/Date(1307970840000)\/"",""Close"":6087.8,""High"":6089.0,""Low"":6087.5,""Open"":6089.0},{""BarDate"":""\/Date(1307970900000)\/"",""Close"":6085.3,""High"":6087.5,""Low"":6085.3,""Open"":6087.5},{""BarDate"":""\/Date(1307970960000)\/"",""Close"":6084.5,""High"":6085.5,""Low"":6084.5,""Open"":6085.5},{""BarDate"":""\/Date(1307971020000)\/"",""Close"":6083.8,""High"":6085.0,""Low"":6083.8,""Open"":6084.8},{""BarDate"":""\/Date(1307971080000)\/"",""Close"":6083.3,""High"":6084.0,""Low"":6083.0,""Open"":6083.5},{""BarDate"":""\/Date(1307971140000)\/"",""Close"":6084.3,""High"":6084.3,""Low"":6082.5,""Open"":6083.0},{""BarDate"":""\/Date(1307971200000)\/"",""Close"":6083.5,""High"":6084.8,""Low"":6083.3,""Open"":6084.0},{""BarDate"":""\/Date(1307971260000)\/"",""Close"":6084.3,""High"":6084.8,""Low"":6083.5,""Open"":6083.8},{""BarDate"":""\/Date(1307971320000)\/"",""Close"":6085.0,""High"":6085.3,""Low"":6083.8,""Open"":6084.8},{""BarDate"":""\/Date(1307971380000)\/"",""Close"":6084.8,""High"":6085.0,""Low"":6084.0,""Open"":6084.8},{""BarDate"":""\/Date(1307971440000)\/"",""Close"":6085.0,""High"":6085.8,""Low"":6084.5,""Open"":6084.8},{""BarDate"":""\/Date(1307971500000)\/"",""Close"":6085.0,""High"":6086.3,""Low"":6084.8,""Open"":6085.3},{""BarDate"":""\/Date(1307971560000)\/"",""Close"":6086.3,""High"":6086.5,""Low"":6084.8,""Open"":6084.8},{""BarDate"":""\/Date(1307971620000)\/"",""Close"":6085.0,""High"":6085.5,""Low"":6085.0,""Open"":6085.5},{""BarDate"":""\/Date(1307971680000)\/"",""Close"":6083.3,""High"":6084.8,""Low"":6083.3,""Open"":6084.8}]";
        public static Market[] GetMarkets()
        {
            return JsonConvert.DeserializeObject<Market[]>(markets);
        }

        public static PriceBar[] GetPriceHistory(int marketId, int numberOfBars)
        {
            if (marketId == 400520618) //uk 100
            {
                return JsonConvert.DeserializeObject<PriceBar[]>(uk100bars).AsQueryable()
                    .Take(numberOfBars).ToArray();
            }

            return new SinPriceHistoryGenerator(new Aug21TimeGenerator())
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
