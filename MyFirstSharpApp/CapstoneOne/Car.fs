open System

let getDistance (destination) =
    if destination = "Gas" then 10
    elif destination = "Stadium" then 25
    elif destination = "Office" then 50
    elif destination = "Home" then 25
    else failwith "Unknown destination!"

let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    if currentPetrol >= distance then currentPetrol - distance
    else failwith "Oops! You've run out of petrol!"

let driveTo (petrol:int, destination:string) : int =
    let distance = getDistance(destination)
    let remaining = calculateRemainingPetrol(petrol, distance)
    if destination = "Gas" then remaining + 50
    else remaining

let getDestination unit : string = 
    Console.Write("Enter Destination: ")
    Console.ReadLine()

[<EntryPoint>]
let main argv =
    let mutable petrol = 100
    while true do
       try
           let destination = getDestination()
           printfn "Trying to drive to %s" destination
           petrol <- driveTo(petrol, destination)
           printfn "Made it to %s! You have %i petrol left" destination petrol
        with ex -> printfn "ERROR: %s" ex.Message
    0