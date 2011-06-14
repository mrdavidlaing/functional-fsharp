namespace FSharpKoans
open FSharpKoans.Core
open CIAPI

type ``three white soliders``() =
    (* Three white soldiers: A bullish reversal pattern consisting of three consecutive long white bodies. 
      
   See: http://stockcharts.com/school/doku.php?id=chart_school:chart_analysis:candlestick_pattern_  *)

    [<Koan>]
    member this.hasThreeWhiteSoldiers() =
        let marketId = 400520618 //UK 100
        let priceBars = List.ofArray (CIAPI.GetPriceHistory(marketId, 45))
     
        (* Look for 3 consecutive white (rising) bodies *)        
        let hasThreeWhiteSoldiers = priceBars

        AssertEquality hasThreeWhiteSoldiers __
