#load "Domain.fs"
#load "Auditing.fs"
#load "Operations.fs"

open Operations
open Domain
open System

let isValidCommand (command:char) = 
    if command = 'w' || command = 'd' || command = 'x' then true 
    else false

let isStopCommand (command:char) = 
    if command = 'x' then true 
    else false

let getAmount (command:char) = 
    if command = 'd' then (command, 50m)
    else if command = 'w' then (command, 25m)
    else (command, 0m)

let processCommand (account:Account) (command:char, amount:decimal) = 
    if command = 'd' then deposit amount account
    else if command = 'w' then withdraw amount account
    else account

let openingAccount =
    { Owner = { Name = "Isacc" }; Balance = 0m; AccountId = Guid.Empty }

let account =
    let commands = ['d';'w';'z';'f';'d';'x';'w']
    commands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount


