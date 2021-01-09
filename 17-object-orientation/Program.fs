// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Classes

[<EntryPoint>]
let main argv =
    let namePrompt = ConsolePrompt("Please enter your name", 3)
    namePrompt.BeepOnError <- false
    namePrompt.ColorScheme <- ConsoleColor.Cyan, ConsoleColor.DarkGray
    let name = namePrompt.GetValue()
    printfn "Hello %s" name
 
    let colorPrompt = ConsolePrompt("What is your favorite color (press Enter if you don't have one)", 1)
    let favouriteColor = colorPrompt.GetValue()
 
    let person = Person(name, favouriteColor)
    printfn "%s" (person.Description())
    
    0 // return an integer exit code