open System

for number in 1 .. 10 do
    printfn "%d hello!" number


for number in 10 .. -1 .. 1 do
    printfn "%d hello!" number

let customerIds = [ 45 .. 99 ]    

for even in 2 .. 2 .. 10 do
    printfn "%d is an even number!" even


let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper(c) |]

let listOfSquares = [ for i in 1 .. 10 -> i * i ]

let seqOfStrings = seq { for i in 2 .. 4 .. 20 -> sprintf "Number %d" i }


