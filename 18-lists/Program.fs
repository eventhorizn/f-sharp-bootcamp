// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Drawing
open ColorManagement

let listColors (history : ColorHistory) =
    history.Colors()
    |> Seq.iter (printf "%A ")
    printfn ""

[<EntryPoint>]
let main argv =
    let numbers = [1; 2; 4; 8; 16]
 
    let moreNumbers = 
        [
            for i in 0..4 -> pown 2 i
        ]
 
    let yetMoreNumbers = List.init 5 (fun i -> pown 2 i)        
 
    let total =
        [ for i in 1..1000 -> i * i ]
        |> List.sum
 
    let thirdNumber = yetMoreNumbers.[2]

    // Error: Property 'item' cannot be set.
    //yetMoreNumbers.[1] <- 99

    let strings = ["the"; "cat"; "sat"]
    printfn "strings: %A" strings
 
    let strings2 = "sometimes" :: strings
    printfn "strings2: %A" strings2

    match strings2 with
    | head::tail ->
        printfn "head: \"%s\", tail: %A" head tail
    | [] ->
        printfn "Empty list"




    printf "I can create a color history with some colors :"
    let history = ColorHistory([Color.Indigo; Color.Violet], 7)
    history |> listColors

    printfn "I can add a color:"
    history.Add(Color.Blue)
    history |> listColors
    printfn "The new color is the latest: "
    printfn "%O" (history.TryLatest())

    printfn "I can re add an existing color - it is 'moved' to latest: "
    history.Add(Color.Indigo)
    history |> listColors

    printfn "When I add colors beyond the maximum length the oldest is/are pushed out: "
    [Color.Green; Color.Yellow; Color.Orange; Color.Red; Color.PeachPuff]
    |> List.iter (history.Add)
    history |> listColors

    printfn "I can explicitly remove the most recent color:"
    history.RemoveLatest()
    history |> listColors
 
    printfn "It doesn't matter if I remove from an empty history:"
    history.RemoveLatest()
    history.RemoveLatest()
    history.RemoveLatest()
    history |> listColors   

    0 // return an integer exit code