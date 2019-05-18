
let getCreditLimit customer =
    match customer with
    | _, 1 -> 250
    | "medium", 1 -> 500
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000


getCreditLimit ("medium", 1)


type Customer =
    {   Balance : int
        Name : string   }

let handleCustomers customers =
    match customers with
    | [] -> failwith "No customers supplied!"
    | [ customer ] -> printfn "Single customer, name is %s" customer.Name
    | [ first; second ] -> printf "Two customers, balance = %d" (first.Balance + second.Balance)
    | customers -> printf "Customers supplied: %d" customers.Length

handleCustomers []
handleCustomers [ { Balance = 10; Name = "Joe" }] 


let getStatus customer =
    match customer with
    | { Balance = 0 } -> "Customer has empty balance!"
    | { Name = "Isacc" } -> "This is a great customer!"
    | { Name = name; Balance = 50 } -> sprintf "%s has a large balance!" name
    | { Name = name } -> sprintf "%s is a normal customer" name
    
{ Balance = 50; Name = "Joe" } |> getStatus