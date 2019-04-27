let drive(petrol, distance) =
    if distance > 50 then petrol / 2.0
    elif distance > 25 then petrol - 10.0
    elif distance > 0 then petrol - 1.0
    else petrol - 1.0

let petrol = 100.0
let firstState = drive(petrol, 60)
let secondState = drive(petrol, 26)
let thirdState = drive(petrol, 5)
let fourthState = drive(petrol, 0)
