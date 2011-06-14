namespace FSharpKoans
open FSharpKoans.Core
open CIAPI

type ``white marubozo``() =
    (* Marubozo: A candlestick with no wick extending from the body at either the open or the close. 
     The name means close-cropped or close-cut in Japanese, though other interpretations refer to it as Bald or Shaven Head.
      
   See: http://stockcharts.com/school/doku.php?id=chart_school:chart_analysis:candlestick_pattern_  *)

    [<Koan>]
    member this.hasWhiteMarubozo() =
        let marketId = 400520618
        let priceBars = List.ofArray (CIAPI.GetPriceHistory(marketId, 45))

     
        (* A white marubozo indicates a strong bull sentiment; since the close is higher than the open *)        
        let hasWhiteMarubozo = priceBars

        AssertEquality hasWhiteMarubozo __
