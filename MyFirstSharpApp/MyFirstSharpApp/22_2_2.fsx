
let aNumber : int = 10
let maybeANumber : int option = Some 10

let calculateAnnualPremiumUsdA score =
    match score with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None -> 
        printfn "No score supplied! Using temporary premium." 
        300

calculateAnnualPremiumUsdA (Some 250)
calculateAnnualPremiumUsdA None


type Driver =
    {   Name : string
        SafetyScore : int option
        YearPassed : int    }


let drivers = 
    [   { Name = "Fred Smith"; SafetyScore = (Some 550); YearPassed = 1980 }
        { Name = "Jane Dunn"; SafetyScore = None; YearPassed = 1980 }   ]


let calculateAnnualPremiumUsd driver =
    match driver with
    | { SafetyScore=(Some 0) } -> 250
    | { SafetyScore=(Some score) } when score < 0 -> 400
    | { SafetyScore=(Some score) } when score > 0 -> 150
    | { SafetyScore=None } -> 
        printfn "No score supplied! Using temporary premium." 
        300

drivers |> Seq.map calculateAnnualPremiumUsd




let tryFindCustomer cId = if cId = 10 then Some drivers.[0] else None
let getSafetyScore customer = customer.SafetyScore
tryFindCustomer 10 |> Option.bind getSafetyScore
tryFindCustomer 20 |> Option.bind getSafetyScore

let test1 = Some 5 |> Option.filter(fun x -> x > 5)
let test2 = Some 5 |> Option.filter(fun x -> x = 5)


let tryLoadCustomer customerId =
    match customerId with
    | n when n > 1 && n < 8 -> Some(sprintf "Customer %i" n)
    | _ -> Option<string>.None


let customerIds = [ 0 .. 10 ]
customerIds |> List.choose tryLoadCustomer

