namespace Core

open System
open Domain
open Operations

module Api =

    let LoadAccount (owner:Customer) =
        match tryLoadAccountFromDisk owner.Name with
        | Some account -> 
            match account with
            | InCredit _ -> account
            | Overdrawn _ -> account
        | None -> { Owner = owner; AccountId = Guid.NewGuid();  Balance = 0m } |> classifyAccount

    let Withdraw amount (owner:Customer) =
        let account = LoadAccount owner
        auditAs "withdraw" Auditing.printTransaction withdraw amount account
    
    
    let Deposit amount (owner:Customer) =
        let account = LoadAccount owner
        auditAs "deposit" Auditing.printTransaction deposit amount account


    let LoadTransactionHistory (owner:Customer) =
        loadTransactionsFromDisk owner.Name