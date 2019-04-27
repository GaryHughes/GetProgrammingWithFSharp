
let text = "Hello, World"
text.Length


let greetPerson name age = sprintf "Hello, %s. You are %d years old" name age
let greeting = greetPerson "Gary" 44

let countWords (text:string) = text.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries).Length;;
let input = "Hello There World";;
let count = countWords input;;
let file = new System.IO.StreamWriter("c:\\temp\\output.txt");;
file.WriteLine(input);;
file.WriteLine(count);;
file.Close();;


