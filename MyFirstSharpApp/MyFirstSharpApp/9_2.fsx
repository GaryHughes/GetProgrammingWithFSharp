
let parseName (name:string) = 
    let parts = name.Split(' ' )
    let forename = parts.[0]
    let surname = parts.[1]
    forename, surname

let name = parseName("Gary Hughes")
let forename, surname = name
let fname, snmae = parseName("Gary Hughes")



let parse (person:string) =
    let parts = person.Split(' ')
    parts.[0], parts.[1], System.Int32.Parse(parts.[2])

let a, b, c = parse("Gary Hughes 1000")


