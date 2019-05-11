// Learn more about F# at http://fsharp.org

open System
open Domain
open Operations
open FileRepository

let auditAs operationName audit operation amount account =
    let result = operation amount account
    let transaction = 
        {   Timestamp = DateTime.UtcNow
            Amount = amount
            Operation = operationName
            Accepted = result.Balance <> account.Balance }
    writeTransaction account transaction
    audit account transaction
    account
    

let withdrawWithAudit = withdraw |> auditAs "withdraw" Auditing.printTransaction
let depositWithAudit = deposit |> auditAs "deposit" Auditing.printTransaction


let isValidCommand (command:char) = 
    if command = 'w' || command = 'd' || command = 'x' then true 
    else false

let isStopCommand (command:char) = 
    if command = 'x' then true 
    else false

let getConsoleAmount (command:char) = 
    Console.Write("Amount: ")
    let amount = Decimal.Parse(Console.ReadLine())
    (command, amount)

let processCommand (account:Account) (command:char, amount:decimal) = 
    if command = 'd' then depositWithAudit amount account
    else if command = 'w' then withdrawWithAudit amount account
    else account

[<EntryPoint>]
let main argv =
    Console.Write("Enter account name: ")
    let name = Console.ReadLine()
    let accountId, transactions = findTransactionsOnDisk name
    let account = loadAccount name accountId transactions
    printfn "%O" account
    let account =
        let commands = seq {
            while true do
                Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
                yield Console.ReadKey().KeyChar
        }
        commands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getConsoleAmount
        |> Seq.fold processCommand account

    printfn "%O" account
    0
