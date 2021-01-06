// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

// Namespace
open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

// Attribute
[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    printfn "The args are: %A" argv
    0 // return an integer exit code