let sum inputs =
    let mutable accumulator = 0
    for input in inputs do
        accumulator <- accumulator + input
    accumulator

sum [1;2;3;4]


let length inputs =
    let mutable accumulator = 0
    for input in inputs do
        accumulator <- accumulator + 1
    accumulator

length [1;2;3;4]


let max inputs =
    let mutable accumulator = 0
    for input in inputs do
        if input > accumulator then
            accumulator <- input
    accumulator

max [20;1000;500;3]