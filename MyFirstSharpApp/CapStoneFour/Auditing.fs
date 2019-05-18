module Auditing

open Domain

let printTransaction transaction =
    printfn "%O: %s %M"
        transaction.Timestamp
        transaction.Operation
        transaction.Amount
        
