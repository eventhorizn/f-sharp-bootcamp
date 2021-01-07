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
