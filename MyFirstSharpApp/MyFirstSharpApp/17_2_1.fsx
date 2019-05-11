open System
open System.IO

let dateDifferenceInDays (one:DateTime, two:DateTime) =
    let difference = two - one
    int difference.TotalDays
    
let infos = 
    Directory.EnumerateDirectories(@"C:\")
    |> Seq.map(fun path -> DirectoryInfo(path))
    |> Seq.map(fun info -> (info.Name, info.CreationTimeUtc))
    |> Map.ofSeq
    |> Map.map(fun name creationTimeUtc -> 
        let difference = dateDifferenceInDays(creationTimeUtc, DateTime.UtcNow)
        (name, difference))




