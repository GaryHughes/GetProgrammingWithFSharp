// Learn more about F# at http://fsharp.org

open System
open Domain
open Operations

let auditAs operationName audit operation amount account =
    let result = operation amount account
    if result.Balance <> account.Balance then
        let message = sprintf "'%s' for %f. Balance is now %f" operationName amount result.Balance
        audit account message
    account

let withdrawWithAudit = withdraw |> auditAs "withdraw" Auditing.consoleAudit
let depositWithAudit = deposit |> auditAs "deposit" Auditing.consoleAudit

[<EntryPoint>]
let main argv =
    Console.Write("Enter account name: ")
    let name = Console.ReadLine()
    Console.Write("Enter initial balance: ");
    let balance = Console.ReadLine()
    let mutable account = { AccountId = Guid.NewGuid()
                            Owner = { Name = name }
                            Balance = Convert.ToDecimal(balance) }
    while true do
        Console.Write("Action (w/d/x): ")
        let action = Console.ReadKey().KeyChar
        if action = 'x' then Environment.Exit 0
        Console.WriteLine()
        Console.Write("Amount: ")
        let rawAmount = Console.ReadLine()
        let amount = Convert.ToDecimal(rawAmount)
        account <- 
            if action = 'd' then account |> depositWithAudit amount 
            elif action = 'w' then account |> withdrawWithAudit amount
            else account

    0 // return an integer exit code
