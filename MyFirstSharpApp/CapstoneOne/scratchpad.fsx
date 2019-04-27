
let getDistance (destination) =
    if destination = "Gas" then 10
    elif destination = "Stadium" then 25
    elif destination = "Office" then 50
    elif destination = "Home" then 25
    else failwith "Unknown destination!"


getDistance "Gas"
getDistance "Stadium"
getDistance "Office"
getDistance "Home"
getDistance "School"


let calculateRemainingPetrol (currentPetrol:int, distance:int) : int =
    if currentPetrol >= distance then currentPetrol - distance
    else failwith "Oops! You've run out of petrol!"

let petrol1 = calculateRemainingPetrol(10, 5)
let petrol2 = calculateRemainingPetrol(10, 10)
let petrol3 = calculateRemainingPetrol(10, 20)


let distanceToGas = getDistance("Gas")
calculateRemainingPetrol(25, distanceToGas)
calculateRemainingPetrol(5, distanceToGas)


let driveTo (petrol:int, destination:string) : int =
    let distance = getDistance(destination)
    let remaining = calculateRemainingPetrol(petrol, distance)
    if destination = "Gas" then remaining + 50
    else remaining


let a = driveTo(100, "Office")
let b = driveTo(a, "Stadium")
let c = driveTo(b, "Gas")
let answer = driveTo(c, "Home")