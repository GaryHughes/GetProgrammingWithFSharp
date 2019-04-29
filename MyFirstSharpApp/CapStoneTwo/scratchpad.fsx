#load "Domain.fs"

open Domain
open System.IO

let fileSystemAudit account message =
    let directory = sprintf @"c:\temp\capstone2\%s" account.Owner.Name
    if not (Directory.Exists directory) then ignore(Directory.CreateDirectory directory)
    let filename = sprintf "%s\\%s.txt" directory (account.AccountId.ToString())
    File.AppendAllText(filename, (sprintf "Account %O: %s" account.AccountId message))
    
let console account message =
    printfn "Account %O: %s" account.AccountId message
    
let deposit amount account =
    {   account with Balance = account.Balance + amount }

let withdraw amount account =
    if amount < account.Balance then account
    else { account with Balance = account.Balance - amount }


open System

let customer = { Name = "Isaac" }
let account = { AccountId = Guid.Empty; Owner = customer; Balance = 90M }

let newAccount = account |> withdraw 10M                                 
newAccount.Balance = 80M 

console account "Testing console audit"                                  