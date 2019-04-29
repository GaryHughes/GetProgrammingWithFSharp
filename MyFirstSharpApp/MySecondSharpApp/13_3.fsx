type Customer = { Age : int }

let printCustomerAge writer customer =
    if customer.Age < 13 then writer "Child"
    elif customer.Age < 18 then writer "Teenager"
    else writer "Adult"

open System

printCustomerAge Console.WriteLine { Age = 3 }
printCustomerAge Console.WriteLine { Age = 13 }
printCustomerAge Console.WriteLine { Age = 22 }

open System.IO

let writeToFile text = File.WriteAllText(@"c:\temp\output.txt", text)

let printToFile = printCustomerAge writeToFile 

printToFile { Age = 21 }

File.ReadAllText(@"c:\temp\output.txt")



