﻿namespace FSharpKoans
open FSharpKoans.Core

type ``about tuples``() =
    
    [<Koan>]
    member this.CreatingTuples() =
        let items = ("apple", "dog")
        
        AssertEquality items __
        
    [<Koan>]
    member this.AccessingTupleElements() =
        let items = ("apple", "dog")
        
        let fruit = fst items
        let animal = snd items
        
        AssertEquality fruit __
        AssertEquality animal __

    (* although you can access the items
       of a two element tuple with fst and snd,
       it's often better to use a technique
       called pattern matching to access the
       elements of a tuple *)
        
    [<Koan>]
    member this.AccessingTupleElementsWithPatternMatching() =
        let items = ("apple", "dog", "Mustang")
        
        let fruit, animal, car = items
        
        AssertEquality fruit __
        AssertEquality animal __
        AssertEquality car __
        
    [<Koan>]
    member this.IgnoringValuesWithPatternMatching() =
        let items = ("apple", "dog", "Mustang")
        
        let _, animal, _ = items
        
        AssertEquality animal __
    
    (* NOTE: pattern matching is found in many places
             throughout F#, and we'll revisit it again later *)
        
    [<Koan>]
    member this.ReturningMultipleValuesFromAFunction() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)
        
        let squared, cubed = squareAndCube 3.0
        
        
        AssertEquality squared __
        AssertEquality cubed __
    
    (* THINK ABOUT IT: Is there really more than one return value?
                       What type does the squareAndCube function
                       return? *)
    
    [<Koan>]
    member this.TheTruthBehindMultipleReturnValues() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)
            
        let result = squareAndCube 3.0
       
        AssertEquality result __