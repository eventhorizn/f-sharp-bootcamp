namespace StudentScores

module Float = 
    let tryFromString s =
        if s = "N/A" then
            Nothing
        else
            Something (float s)

    let fromStringOr50 s =
        s
        |> tryFromString
        |> Optional.defaultValue 50.0

    let fromStringOr d s =
        s
        |> tryFromString
        |> Optional.defaultValue d