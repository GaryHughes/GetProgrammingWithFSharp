module Operations

open Domain
open Auditing

let deposit amount account =
    {   account with Balance = account.Balance + amount }

let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

let loadAccount owner accountId transactions =
    let openingAccount = 
        {   AccountId = accountId
            Owner = { Name = owner }
            Balance = 0m }
    transactions 
    |> Seq.sortBy (fun transaction -> transaction.Timestamp)
    |> Seq.fold(fun account transaction -> 
        if transaction.Operation = "withdraw" then 
            withdraw transaction.Amount account
        else
            deposit transaction.Amount account 
        ) openingAccount
    
