let nameAndAge = ("Gary", "Hughes"), 44
let name, age = nameAndAge
let (forename, surname), theAge = nameAndAge


let addNumbers arguments =
    let a, b = arguments
    a + b

addNumbers(5, 6)

open System

let result, parsed = Int32.TryParse("123")

