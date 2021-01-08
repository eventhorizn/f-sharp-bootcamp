// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

[<EntryPoint>]
let main argv =
    
    let numbers = [|1; 2; 4; 8; 16|]
    printfn "%A" numbers
    
    // must be an expression to do this
    let numbers2 = 
        [|
            for i in 0..4 -> pown 2 i
        |]

    printfn "%A" numbers2


    let todayIsThursday() =
        DateTime.Now.DayOfWeek = DayOfWeek.Thursday

    let isEven x =
        x % 2 = 0

    // The code can be complex
    let evenNums = 
        [|
            if todayIsThursday() then 42
            for i in 1..9 do
                let x = i * i
                if x |> isEven then
                    x // implicit yield
            999
        |]

    printfn "%A" evenNums

    // Array.init
    // 2**4 example
    // first arg is length, second is how to fill it
    let numInit = Array.init 5 (fun i -> pown 2 i)
    printfn "%A" numInit

    let total = 
        [| 
            for i in 1..1000 do  
                yield i * i 
        |]
        |> Array.sum

    printfn "%A" total

    let totalInit = 
        Array.init 1000 (fun i ->
            let x = i + 1
            x * x)
        |> Array.sum

    printfn "%A" totalInit


    // Array.zeroCreate
    let initiallyZeros = Array.zeroCreate<int> 10
    printfn "%A" initiallyZeros

    0 // return an integer exit code