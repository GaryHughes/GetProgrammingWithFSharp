module Auditing

open System
open System.IO
open Domain

let fileSystemAudit account message =
    let directory = sprintf @"c:\temp\capstone2\%s" account.Owner.Name
    if not (Directory.Exists directory) then ignore(Directory.CreateDirectory directory)
    let filename = sprintf "%s\\%s.txt" directory (account.AccountId.ToString())
    File.AppendAllText(filename, (sprintf "Account %O: %s" account.AccountId message))
       
let consoleAudit account message =
    printfn "Account %O: %s" account.AccountId message
   

    
