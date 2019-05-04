let numbers = [ 1 .. 10 ]
let timesTwo n = n * 2
let outputImperative = ResizeArray()
for number in numbers do
    outputImperative.Add(number |> timesTwo)
let outputFunctional = numbers |> List.map timesTwo

let addTwo x y = x + y
let a = [ 1..5 ]
let b = [ 6..10 ]
let c = List.map2 addTwo a b

c |> List.iter(fun(x) -> printfn "%i" x)

