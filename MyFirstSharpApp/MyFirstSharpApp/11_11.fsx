
let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let startPetrol = 100.0

startPetrol |> drive "far" |> drive "medium" |> drive "short"


open System
open System.IO

let checkCreation date =
    Console.WriteLine(date.ToString())

let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory >> Directory.GetCreationTime >> checkCreation

checkCurrentDirectoryAge()
