open System
open System.IO

module Float = 
    let tryFromString s =
        if s = "N/A" then
            None
        else
            Some (float s)

    let fromStringOr50 s =
        s
        |> tryFromString
        |> Option.defaultValue 50.0

    let fromStringOr d s =
        s
        |> tryFromString
        |> Option.defaultValue d

type Student =
    {
        Name: string
        Id: string
        MeanScore: float
        MinScore: float
        MaxScore: float
    }

module Student = 
    let fromString (s: string) =
        let elements = s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]
        let scores =
            elements
            |> Array.skip 2
            //|> Array.choose Float.tryFromStringOr50
            //|> Array.map Float.fromStringOr50
            |> Array.map (Float.fromStringOr 50.0)
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Name = name
            Id = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }

    let printSummary (student: Student) =
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let summarize filePath =
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1
    printfn "Student Count %i" studentCount

    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortByDescending (fun student -> student.MeanScore) // lambda function
    |> Array.iter Student.printSummary
    

[<EntryPoint>]
let main argv =
    let filePath = "Samples/StudentScoresNA.txt"

    summarize filePath
    0 // return an integer exit code