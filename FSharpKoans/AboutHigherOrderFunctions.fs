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

(* TODO -- further samples *)