module FileRepository

open System
open System.IO
open Domain

let serialized transaction =
    sprintf "%O***%s***%M***%b"
        transaction.Timestamp
        transaction.Operation
        transaction.Amount
        transaction.Accepted

let deserialize (serialized:string) =
    let components = serialized.Split("***")
    let transaction = {
        Timestamp = DateTime.Parse(components.[0])
        Operation = components.[1]
        Amount = Decimal.Parse(components.[2])
        Accepted = bool.Parse(components.[3])
    }
    transaction
   
let writeTransaction account transaction =
    let directory = sprintf @"c:\temp\capstone3\%s" account.Owner.Name
    if not (Directory.Exists directory) then ignore(Directory.CreateDirectory directory)
    let filename = sprintf "%s\\%s" directory (account.AccountId.ToString())
    File.AppendAllText(filename, (serialized transaction) + "\n")
    
let findTransactionsOnDisk owner =
    let directory = sprintf @"c:\temp\capstone3\%s" owner
    if not (Directory.Exists directory) || Directory.EnumerateFiles(directory) |> Seq.isEmpty then
        (Guid.NewGuid(), Seq.empty)
    else
        let filename = Directory.EnumerateFiles(directory) |> Seq.head
        let transactions =
            File.ReadAllLines(filename)
            |> Seq.map(deserialize)
        let accountId = Guid.Parse(Path.GetFileName(filename))
        (accountId, transactions)
    
    

