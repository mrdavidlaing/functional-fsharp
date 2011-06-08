namespace FSharpKoans
open FSharpKoans.Core

type ``about first class functions``() =

    (* A language supports first-class functions when: 

       (1) You can bind an identifier to the function, 
            i.e. you can give it a name 

       (2) You can store the function in a 
           data structure (e.g: a list) 

       (3) You can pass the function as 
           an argument in another function call 

       (4) You can return a function 
           from another function *)
      
    [<Koan>]
    member this.GivingFunctionsANameWithLet() =
     (* By default, F# is whitespace sensitive.
       For functions, this means that the last
       line of a function is its return value,
       and the body of a function is denoted
       by indentation. *)

        let add x y =
            x + y

        let result1 = add 2 2
        let result2 = add 5 2
        
        
        AssertEquality result1 __
        AssertEquality result2 __
        
       (* See how functions are given names just like other variables *)


    [<Koan>]
    member this.StoringFunctionsInADataStructure() =
        let add x y =
            x + y
        let subtract x y =
            x - y
        
        let operations = [add, subtract, add, subtract, subtract, add]

        (* Hmm.  Now how do I apply each operation from the List? 
          ala:

          for (i in operations) { 
               result = operations[i](result,5); 
               // log("result is now:", result); 
            } 
        *)
        let result = __

        AssertEquality result __
 
    [<Koan>]
    member this.PassingAFunctionToAnotherAsAnArgument() =
        
        (* TODO - see http://msdn.microsoft.com/en-us/library/dd233158.aspx for syntax *)

        let result = __

        AssertEquality result __

    [<Koan>]
    member this.ReturningAFunctionFromAnotherFunction() =
        
        (* TODO - see http://msdn.microsoft.com/en-us/library/dd233158.aspx for syntax *)

        let result = __

        AssertEquality result __