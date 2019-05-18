// Learn more about F# at http://fsharp.org

open System
open System.IO
open Domain
open Operations
open FileRepository
open Commands


let tryLoadAccountFromDisk owner =
    let directory = sprintf @"c:\temp\capstone4\%s" owner
    if not (Directory.Exists directory) || Directory.EnumerateFiles(directory) |> Seq.isEmpty then
        None
    else
        let filename = Directory.EnumerateFiles(directory) |> Seq.head
        let transactions =
            File.ReadAllLines(filename)
            |> Seq.map(deserialize)
        let accountId = Guid.Parse(Path.GetFileName(filename))
        Some(loadAccount owner accountId transactions)


let withdrawWithAudit amount (CreditAccount account) =
    let classified = classifyAccount account
    auditAs "withdraw" Auditing.printTransaction withdraw amount classified
 
let depositWithAudit amount (account:RatedAccount) =
    auditAs "deposit" Auditing.printTransaction deposit amount account


let getConsoleAmount (command:BankOperation) = 
    Console.WriteLine()
    Console.Write("Enter Amount: ")
    let amount = Console.ReadLine() |> Decimal.TryParse
    match amount with
    | true, amount -> Some(command, amount)
    | false, _ -> None

let processCommand (account:RatedAccount) (command:BankOperation, amount:decimal) =
    match command with
    | Deposit -> depositWithAudit amount account
    | Withdraw -> 
        match account with
        | InCredit account -> withdrawWithAudit amount account
        | Overdrawn _ -> account

[<EntryPoint>]
let main argv =
    let account =
        Console.Write("Enter account name: ")
        let owner = Console.ReadLine()
        match (tryLoadAccountFromDisk owner) with
        | Some account -> account
        | None -> 
            { Balance = 0M
              AccountId = Guid.NewGuid()
              Owner = { Name = owner } } |> classifyAccount
    printfn "%O" account
    let account =
        let commands = seq {
            while true do
                Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
                yield Console.ReadKey().KeyChar
        }
        commands
        |> Seq.choose tryParseCommand
        |> Seq.takeWhile(fun c -> 
            match c with 
            | Exit -> false
            | _ -> true
            )
        |> Seq.choose tryGetBankOperation
        |> Seq.choose getConsoleAmount
        |> Seq.fold processCommand account

    printfn "%O" account
    0
