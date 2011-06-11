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
        
        let operationsList = [add; subtract; add; subtract; subtract; add; add]

        let mutable result = 0

        for operation in operationsList do
            result <- (operation result 5)
            //printfn "result = %A" result            

        AssertEquality result __
        (* And since they have names; we can store them in a list,
            just like other variables *)
    
    [<Koan>]
    member this.PassingAFunctionToAnotherAsAnArgument() =
        
        let square x = 
            x * x
        
        let mapToEveryElement theList theFunction = 
            let resultList = [ for item in theList do
                                    yield theFunction item ]
            resultList  

        let result = (mapToEveryElement [1..5] square)
        (* notice how we're passing in the square function as an argument *)

        //printfn "result = \n%A\n\n" result
        AssertEquality result __

    [<Koan>]
    member this.ReturningAFunctionFromAnotherFunction() =
        
        let powerFactory power = 
            //printfn "Executing powerFactory %A\n" power 
            let powerFunction number = 
                let mutable result = 1
                for i in [1..power] do
                    result <- result * number
                result
            powerFunction
        
        //printfn "Creating squared\n"
        let squared = powerFactory 2
        let cubed = powerFactory 3

        //printfn "Using squared\n"
        let result = squared 1 + squared 2 + cubed 3

        AssertEquality result __
        
        (* When is the powerFactory function executed? 
           Once on creation of squared?
           Every time we call a created function?
         *)