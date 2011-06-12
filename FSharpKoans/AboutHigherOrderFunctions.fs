namespace FSharpKoans
open FSharpKoans.Core
open CIAPI

type ``about higher order functions``() =

    (*  The following are known as higher order functions: 
        
        (1) iter 
        (2) map 
        (3) filter 
        (4) reduce 
        (5) forall 
        (6) exists 
                
        because they apply a function to a list in a common way. 
        
        Abstracting away the mechanics of an operation is one of the
        ways that functinal programming promotes a declarative style.*)

        (* See http://msdn.microsoft.com/en-us/library/ee353738.aspx *)
      
    [<Koan>]
    member this.IterAppliesTheFunctionToEachElement() =

        (* CIAPI is a helper library that pulls data from 
           the CityIndex Ltd Trading API *)
        let markets = List.ofArray (CIAPI.GetMarkets())

        let printMarketName (market:Market) =
           printfn "Market=%s" market.Name

        (* List.iter Applies the given function to each element of the collection *)        
        List.iter printMarketName markets
         
        AssertEquality markets.Length __

        (* notice how we've capture a common pattern (foreach)
           into a single higher order statement.
           Instead of looping over the list and calling the function each time
           we apply the function to the list of markets *)        

    [<Koan>]
    member this.MapCreatesNewCollectionFromResultOfApplyingTheFunctionToEachElement() =
     
        let markets = List.ofArray (CIAPI.GetMarkets())

        let getMarketNameSummary (market:Market) =
            market.Name.Substring(0, 3).Trim()

        (* List.map Creates a new collection whose elements are the 
           results of applying the given function to each of the 
           elements of the collection. *)        
        let marketSummaries = List.map getMarketNameSummary markets
        
        AssertEquality marketSummaries __
     (* map is very similar to iter, except that the a new collection
        of the results is returned *) 

    [<Koan>]
    member this.FilterCreatesNewCollectionContainingPredicateSatisfyingElements() =
     
        let markets = List.ofArray (CIAPI.GetMarkets())

        let isMarketRising (market:Market) =
            let lastPriceBar = CIAPI.GetPriceHistory(market.MarketId, 1).[0]
            lastPriceBar.Close > lastPriceBar.Open

        (* List.filter Returns a new collection containing only the elements 
           of the collection for which the given predicate returns true. *)        
        let risingMarkets = List.filter isMarketRising markets
         
        printfn "%A" risingMarkets

        AssertEquality risingMarkets __

       (* filter is really useful for, er, filtering :) *) 

    [<Koan>]
    member this.ReduceAppliesAFunctionToEachElementInTurnProducingASingleValue() =
        let marketId = 400520618
        let priceBars = List.ofArray (CIAPI.GetPriceHistory(marketId, 20))

        let getHighest (previousHighest:PriceBar) (current:PriceBar) =
            //printfn "previousHighest: %A current: %A" previousHighest.High current.High 
            if current.High > previousHighest.High then
                current
            else
                previousHighest

        (* List.reduce iter­ates through each ele­ment of a list, 
           build­ing up an accu­mu­la­tor value, which is the sum­mary of the 
           pro­cess­ing done on the list so far. Once every list item has 
           been processed, the final accu­mu­la­tor value is returned, 
           the accumulator’s ini­tial value in List.reduce is the 
           first ele­ment of the list. *)        
        let highestPriceBar = List.reduce getHighest priceBars

        AssertEquality highestPriceBar.High __

       (* reduce is a less generic version of a fold operation. *) 
   
    [<Koan>]
    member this.ForAllTestsAllElements() =
        (* List.forall Tests if all elements of the collection satisfy 
                       the given predicate. *)  
        let marketId = 400520618
        let priceBars = List.ofArray (CIAPI.GetPriceHistory(marketId, 35))

        let isHigherThan198 (current:PriceBar) =
            //printfn "current.Low: %A" current.Low 
            current.Low > 198m

        (* Imagine you had a stop order set at 198.  Would it be triggered?*)        
        let triggersStop = List.forall isHigherThan198 priceBars

        AssertEquality triggersStop __

       (* Are all the elements in the collection checked? *) 

(* TODO -- further samples *)