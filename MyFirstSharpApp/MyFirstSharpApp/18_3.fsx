open System

type Rule = string -> bool * string

let rules : Rule list =
    [   fun text -> 
            printfn "Running 1" 
            (text.Split ' ').Length = 3, "Must be thee words"
        fun text -> 
            printfn "Running 2"
            text.Length <= 30, "Max length is 30 characters"
        fun text -> 
            printfn "Running 3"
            text
            |> Seq.filter Char.IsLetter
            |> Seq.forall Char.IsUpper, "All letters must be caps" 
        fun text ->
            printf "Running 4"
            text
            |> Seq.forall (fun c -> 
                               let isnum = Char.IsNumber c
                               not isnum), "No numbers"
    ]



let validateManual (rules:Rule list) word =
    let passed, error = rules.[0] word
    if not passed then false, error
    else
        let passed, error = rules.[1] word
        if not passed then false, error
        else
            let passed, error = rules.[2] word
            if not passed then false, error
            else true, ""


validateManual rules "BLAH BLAH BLAH"


let buildValidator (rules : Rule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error)

let validate = buildValidator rules
let word = "HELLO FROM F#"

validate word



