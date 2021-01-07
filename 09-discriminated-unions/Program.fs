open System
open System.IO
open StudentScores

[<EntryPoint>]
let main argv =
    let filePath = "Samples/StudentScoresAE.txt"

    Summary.summarize filePath
    0 // return an integer exit code