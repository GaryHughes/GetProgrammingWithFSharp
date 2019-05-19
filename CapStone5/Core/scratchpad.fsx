
#I @"C:\Users\Gary Hughes\.nuget\packages"

#r @"NETStandard.Library\2.0.0\build\netstandard2.0\ref\netstandard.dll"
#r @"C:\Users\Gary Hughes\.nuget\packages\Newtonsoft.Json\12.0.2\lib\netstandard2.0\Newtonsoft.Json.dll"

#load "Domain.fs"

open Newtonsoft.Json
open System
open Core.Domain

let txn = 
    {   Transaction.Amount = 100m
        Timestamp = DateTime.UtcNow
        Operation = "withdraw" }

let serialized = txn |> JsonConvert.SerializeObject

let deserialized = JsonConvert.DeserializeObject<Transaction>(serialized)



