namespace Core

module internal FileRepository =

    open System
    open System.IO
    open System.Text.RegularExpressions
    open Domain
    open Newtonsoft.Json

    let serialized transaction =
        JsonConvert.SerializeObject transaction
  
    let deserialize (serialized:string) =
        let transaction = JsonConvert.DeserializeObject<Transaction>(serialized)
        transaction
   
    let writeTransaction owner (accountId:Guid) transaction =
        let directory = sprintf @"c:\temp\capstone5\%s" owner
        if not (Directory.Exists directory) then ignore(Directory.CreateDirectory directory)
        let filename = sprintf "%s\\%s" directory (accountId.ToString())
        File.AppendAllText(filename, (serialized transaction) + "\n")
    


        
    

