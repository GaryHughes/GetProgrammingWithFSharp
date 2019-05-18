module Operations

open System
open Domain
open FileRepository

let classifyAccount account =
    if account.Balance >= 0m then (InCredit(CreditAccount account))
    else Overdrawn account

let deposit amount (account:RatedAccount) =
    let account =
        match account with
        | InCredit (CreditAccount account) -> account
        | Overdrawn account -> account
    { account with Balance = account.Balance + amount }
    |> classifyAccount
    
let withdraw amount (account:RatedAccount) =
    let account =
        match account with
        | InCredit (CreditAccount account) -> { account with Balance = account.Balance - amount }
        | Overdrawn account -> account
    account |> classifyAccount
    
let auditAs operationName audit operation amount account =
    let updatedAccount = operation amount account
    let transaction = 
        {   Timestamp = DateTime.UtcNow 
            Amount = amount
            Operation = operationName }
    match account with
    | InCredit (CreditAccount credit) -> writeTransaction credit.Owner.Name credit.AccountId transaction
    | Overdrawn overdrawn -> writeTransaction overdrawn.Owner.Name overdrawn.AccountId transaction
    audit transaction
    updatedAccount

let loadAccount owner accountId transactions =
    let openingAccount = 
        {   AccountId = accountId
            Owner = { Name = owner }
            Balance = 0m } |> classifyAccount
    transactions 
    |> Seq.sortBy (fun transaction -> transaction.Timestamp)
    |> Seq.fold(fun account transaction -> 
        if transaction.Operation = "withdraw" then
            match account with
            | InCredit _ -> withdraw transaction.Amount account
            | Overdrawn _ -> account
        else
            deposit transaction.Amount account 
        ) openingAccount





    
