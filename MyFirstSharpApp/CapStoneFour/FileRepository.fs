module FileRepository

open System
open System.IO
open Domain

let serialized transaction =
    sprintf "%O***%s***%M"
        transaction.Timestamp
        transaction.Operation
        transaction.Amount
  
let deserialize (serialized:string) =
    let components = serialized.Split("***")
    let transaction = {
        Timestamp = DateTime.Parse(components.[0])
        Operation = components.[1]
        Amount = Decimal.Parse(components.[2])
    }
    transaction
   
let writeTransaction owner (accountId:Guid) transaction =
    let directory = sprintf @"c:\temp\capstone4\%s" owner
    if not (Directory.Exists directory) then ignore(Directory.CreateDirectory directory)
    let filename = sprintf "%s\\%s" directory (accountId.ToString())
    File.AppendAllText(filename, (serialized transaction) + "\n")
    


        
    

