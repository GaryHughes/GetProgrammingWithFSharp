module Auditing

open Domain

let printTransaction account transaction =
    printfn "%O: %s %M %b"
        transaction.Timestamp
        transaction.Operation
        transaction.Amount
        transaction.Accepted 
