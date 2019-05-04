let numbersArray = [| 1; 2; 3; 4; 6 |]
let firstNumber = numbersArray.[0]
let firstThreeNumbers = numbersArray.[0..2]
numbersArray.[0] <- 99


let numbers = [ 1; 2; 3; 4; 5; 6 ]
let numbersQuick = [ 1 .. 6 ]
let head :: tail = numbers
let moreNumbers = 0 :: numbers
let evenMoreNumbers = moreNumbers @ [7 .. 9 ]

