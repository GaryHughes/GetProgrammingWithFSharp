
let sum inputs =
    Seq.fold(fun state input -> state + input) 0 inputs


sum [1;2;3;4]


let length inputs =
    Seq.fold(fun state input -> state + 1) 0 inputs

length [1;2;3;4]

let max inputs =
    Seq.fold(fun state input -> if input > state then input else state) 0 inputs

max [20;1000;500;3]


