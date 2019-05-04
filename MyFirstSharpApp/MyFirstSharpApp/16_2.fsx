type Order = { OrderId : int }
type Customer = { CustomerId : int; Orders : Order list; Town : string }
let customers : Customer list = []
let orders : Order list = customers |> List.collect(fun c -> c.Orders)



open System
[   DateTime(2010,5,1)
    DateTime(2010,6,1)
    DateTime(2010,6,12)
    DateTime(2010,7,3) ]
|> List.pairwise
|> List.map(fun (a, b) -> b - a)
|> List.map(fun time -> time.TotalDays)