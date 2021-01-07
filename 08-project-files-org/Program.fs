open System
open System.IO
open StudentScores

[<EntryPoint>]
let main argv =
    let filePath = "Samples/StudentScoresNA.txt"

    Summary.summarize filePath
    0 // return an integer exit code