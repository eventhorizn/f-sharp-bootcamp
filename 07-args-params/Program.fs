// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let add a b = 
    a + b

let c = add 2 3

// not an error
// partial application of curried function
let d = add 2

let e = d 4

let quote symbol s = 
    sprintf "%c%s%c" symbol s symbol // returns string instead of prints

let singleQuote = quote '\''
let doubleQuote = quote '"'

[<EntryPoint>]
let main argv =
    printfn "e: %i" e
    printfn "%s" (singleQuote "It was the best of times, it was the worst of times")
    printfn "%s" (doubleQuote "It was the best of times, it was the worst of times")
    0 // return an integer exit code