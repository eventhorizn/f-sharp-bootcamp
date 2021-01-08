// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO

module Dates =
 
    let from (startDate : DateTime) =
        Seq.initInfinite (fun i -> startDate.AddDays(float i))

module MathSequence =
 
    type State = { N : int; Pn2 : int; Pn1 : int }
 
    // seq.Unfold is confusing
    let pell =
        { N = 0; Pn2 = 0; Pn1 = 0 }
        |> Seq.unfold (fun state ->
            let pn =
                match state.N with
                | 0 | 1 
                    -> state.N
                | _ 
                    -> 2 * state.Pn1 + state.Pn2
            let n' = state.N + 1
            Some(pn, { N = n'; Pn2 = state.Pn1; Pn1 = pn } ))


module Drunkard =
 
    let r = Random()
 
    /// Returns a random integer between -1 and +1 inclusive:
    let step() =
        r.Next(-1, 2)
 
    type Position = { X : int; Y : int }
 
    let walk =
        { X = 0; Y = 0 }
        |> Seq.unfold (fun position ->
            let x' = position.X + step()
            let y' = position.Y + step()
            let position' = { X = x'; Y = y' }
            Some(position', position'))

[<EntryPoint>]   
let main argv =
   
    // This is potentially inefficient
    // Uses memory when we don't need to
    let total = 
        [| 
            for i in 1..1000 -> i * i
        |]
        |> Array.sum

    printfn "%A" total

    // seq are computed on demand
    // Creating seq thru seq comprehension
    let totalSeq = 
        seq { for i in 1..1000 -> i * i }
        |> Seq.sum


    //let rows = File.ReadLines "" |> Seq.cache // This returns a sequence
    
    let totalInit = 
        Seq.init 1000 (fun i -> 
            let x = i + 1
            x * x)
        |> Seq.sum
    
    // Can init infinite unlike arrays
    let squares = 
        Seq.initInfinite (fun i -> 
            let x = i + 1
            x * x)

    // in practice we truncate after
    let total = 
        squares
        |> Seq.truncate 1000
        |> Seq.sum

    Dates.from DateTime.Now
    |> Seq.filter (fun d -> d.Month = 1 && d.Day = 1)
    |> Seq.truncate 10
    |> Seq.iter (fun d -> printfn "%i %s" d.Year (d.DayOfWeek.ToString()))

    MathSequence.pell
    |> Seq.truncate 10
    |> Seq.iter (fun x -> printf "%i, " x)

    printfn "..."

    printf "Drunkard's walk"
    Drunkard.walk
    |> Seq.take 100
    |> Seq.iter (fun p -> printfn "X: %i Y: %i" p.X p.Y)

    0 // return an integer exit code