// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

// Namespace
open System

// Good ex of a function!
let sayHello person =
    printfn "Hello %s from my F# program!" person

// Array.iter
// Higher order function
// Function where argument is a function
// In f# functions are 1st class values (can assign to vars)
let arrayIter argv = 
     Array.iter sayHello argv
     printfn "Nice to meet you"

// Attribute
[<EntryPoint>]
let main argv =
    let mutable personBad = "Anonymous Person" // mutable lets us change a variable

    // this isn't considered good f# code
    if argv.Length > 0 then
        personBad <- argv.[0]

    // Why is this better?
    // Minimize use of 'mutable' variables
    let person =
        if argv.Length > 0 then
            argv.[0]
        else
            "Anonymous Person"

    printfn "Hello %s from my F# program" person

    // Loops and Iteration
    // Worst way to implement in f#
    for i in 0..argv.Length - 1 do
        let person = argv.[i]
        printfn "Hello %s from my F# program!" person
    printfn "Nice to meet you."   

    // Iterator approach
    // Much simpler, less chance of bugs
    for person in argv do
        printfn "Hello %s from my F# program!" person

    0 // return an integer exit code