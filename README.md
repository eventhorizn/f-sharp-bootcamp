# F# Bootcamp

## Getting Set Up

1. .Net Core Installed
1. Ionide extension
1. Bracket Pair Colorizer 2

## Managing a Project

1. Create a project
   ```cmd
   dotnet new console -lang F#
   ```
1. Running a project
   ```cmd
   dotnet run
   ```
1. Debugging
   - Use the Ionide extension
   - Can set up VS code debugging files, but annoying

## F# Notes

1. Last line in a function is what is returned
1. Array: array.[0] (annoying .)
1. Format specifiers are strongly typed
   ```f#
   printfn "Hello %s from my F# program" person
   ```
1. Minimize mutable variables
   ```f#
   let mutable person = "Anonymous Person"
   ```
1. When to use type annotations?
   - Type inference is pretty good for the most part
   - Type methods usually require type annotations
   ```f#
   let fromStringOr (d: float) (s: string) : float =
        s
        |> tryFromString
        |> Option.defaultValue d
   ```
   - Example, not really needed
1. When adding files, use ionide ext
   - My guess, is you need to do reference stuff too
   - File order matters in compilation
1. Records vs Anonymous Records
   - {...} means record type
   - {|...|} means anonymous record
   - You'd use anonymous records when returning tupules
     - Gives you named fields to use
1. Arrays are mutable

## Forward Piping

1. Arguments often have no brackets
   - Separated by spaces
   ```f#
   let arrayIter argv =
     Array.iter sayHello argv
     printfn "Nice to meet you"
   ```
   - This serves a purpose: forward piping
1. Forward pipe operator
   ```f#
   argv
    |> Array.filter isValid
    |> Array.iter sayHello
   ```

## Modules

1. Modules are used to associate record types w/ functionality
1. Use the same name b/t a record and a module

```f#
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
            |> Array.map float
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
```

## Parameters

1. Curried parameters

   ```f#
   let fromStringOr d s: float =
   s
   |> tryFromString
   |> Option.defaultValue d
   ```

   - Function parameters which support partial application
   - When an argument is supplied, the result is a function that expects any remaining params
   - When all args have been supplied, the function returns a result

   ```f#
   let add a b =
    a + b

   let c = add 2 3

   // not an error
   // partial application of curried function
   let d = add 2

   let e = d 4
   ```

   - This causes lots of bugs due to it not throwing an error, but just returning a function

1. Tupule Parameters
   ```f#
   let fromStringOr (d, s): float =
      s
      |> tryFromString
      |> Option.defaultValue d
   ```

## Discriminated Unions & Match Expressions

1. Discriminated Unions

```f#
type TestResult =
    | Absent
    | Excused
    | Voided
    | Scored of float
```

1. Match Expressions

```f#
 let tryEffectiveScore (testResult: TestResult) =
        match testResult with
        | Absent -> Some 0.0
        | Excused
        | Voided -> None
        | Scored score -> Some score
```

- The default case

  ```f#
  let nameParts (s: string) =
        let elements = s.Split(',')
        match elements with
        | [|surname; givenName|] ->
           surname.Trim(), givenName.Trim()
        | _ ->
           raise (System.FormatException(sprintf "Invalid name format: \"%s\"" s))
  ```

- Use rarely as when you add a new item in the union, you may forget to add a handle in the match expression
  - Which would then hit the default case

## Array Comprehension

```f#
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
```
