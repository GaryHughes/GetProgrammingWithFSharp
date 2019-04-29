// Learn more about F# at http://fsharp.org

open System
open Domain
open Operations

[<EntryPoint>]
let main argv =
    let joe = { FirstName = "Joe"; LastName = "Bloggs"; Age = 21 }
    if joe |> isOlderThan 18 then printfn "%s is an adult!" joe.FirstName
    else printfn "%s is a child." joe.FirstName
    0
