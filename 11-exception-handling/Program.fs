open System
open StudentScores

[<EntryPoint>]
let main argv =

    let filePath = "Samples/StudentScoresAllEs.txt"
    try
        Summary.summarize filePath
        0 // return an integer exit code
    with
    | :? FormatException as e ->
        printfn "Error: %s" e.Message
        printfn "The file was not in the expected format."
        1
    | :? IO.IOException as e ->
        printfn "Error: %s" e.Message
        printfn "The file is open in another program."
        2
    | e ->
        printfn "Unexpected error: %s" e.Message
        3