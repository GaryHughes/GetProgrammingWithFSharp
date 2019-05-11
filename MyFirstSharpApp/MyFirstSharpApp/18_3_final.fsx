open System
open System.IO

type Rule = string -> bool * string

let rules : Rule list =
    [   fun file ->
            let info = FileInfo(file)
            printfn "%s -> %s" file info.Extension
            info.Extension = ".txt", "Extension must be .txt"
    ]


let buildValidator (rules : Rule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun path ->
            let passed, error = firstRule path
            printfn "one passed = %b error = %s" passed error
            if passed then
                let passed, error = secondRule path
                printfn "two passed = %b error = %s" passed error
                if passed then true, "" else false, error
            else false, error)
    
let validate = buildValidator rules
let path = @"C:\Downloads\Test\test.xt"
    
validate path


Directory.EnumerateFiles(path) 
|> Seq.map(fun file -> Path.Combine(path, file))
|> validate
    