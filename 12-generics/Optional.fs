namespace StudentScores

// Our own version of Option

type Optional<'T> = 
    | Something of 'T
    | Nothing

module Optional = 
    let defaultValue(d: 'T) (optional: Optional<'T>) =
        match optional with
        | Something v -> v
        | Nothing -> d

module Demo =
    let a = Something "abc"
    let b = Something 1
    let c = Something 1.2
    let d = Nothing