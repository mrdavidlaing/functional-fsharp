namespace FSharpKoans
open FSharpKoans.Core

type ``about higher order functions``() =

    (*  The following are known as higher order functions: 
        
        (1) iter 
        (2) map 
        (3) filter 
        (4) reduce 
        (5) forall 
        (6) exists 
                
        because they apply a function to a list in a common way. *)

        (* See http://msdn.microsoft.com/en-us/library/ee353738.aspx *)
      
    [<Koan>]
    member this.IterAppliesTheFunctionToEachElement() =
     
        (* TODO *)
        let result1 = __
        AssertEquality result1 __
        
    [<Koan>]
    member this.MapCreatesNewCollectionFromResultOfApplingTheFunctionToEachElement() =
     
        (* TODO *)
        let result1 = __
        AssertEquality result1 __

(* TODO -- further samples *)