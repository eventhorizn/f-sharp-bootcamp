namespace StudentScores

module Summary = 
    open System.IO
     
    let summarize filePath =
        let rows = File.ReadAllLines filePath
        let studentCount = (rows |> Array.length) - 1
        printfn "Student Count %i" studentCount

        rows
        |> Array.skip 1
        |> Array.map Student.fromString
        |> Array.sortByDescending (fun student -> student.MeanScore) // lambda function
        |> Array.iter Student.printSummary