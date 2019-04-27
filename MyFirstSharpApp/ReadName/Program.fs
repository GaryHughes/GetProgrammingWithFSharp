// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let extractFirstName (fullname:string) = 
        let components = fullname.Split(' ')
        components.[0]
    Console.Write("Please enter your full name: ")
    let fullName = Console.ReadLine()
    Console.WriteLine(extractFirstName fullName)
    0 // return an integer exit code
