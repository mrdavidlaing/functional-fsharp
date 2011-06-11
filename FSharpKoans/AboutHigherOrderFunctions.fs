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
    member this.MapCreatesNewCollectionFromResultOfApplingTheFunctionToEachElement() =
     
        (* TODO *)
        let result1 = __
        AssertEquality result1 __

(* TODO -- further samples *)