type Customer = { Age : int }

let where filter customers =
    seq {
        for customer in customers do
            if filter customer then
                yield customer }

let customers = [ { Age = 21 }; { Age = 35 }; { Age = 36 }; ]

let isOver35 customer = customer.Age > 35

customers |> where isOver35

customers |> where (fun customer -> customer.Age > 35)

