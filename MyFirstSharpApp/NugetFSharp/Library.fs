module Library

open Newtonsoft.Json
open Humanizer

type Person = { Name : string; Age : int }

let getPerson() =
    let text = """{ "Name" : "Same", "Age" : 18 }"""

    let person = JsonConvert.DeserializeObject<Person>(text)
    
    printfn "Name is %s with age %d." person.Name person.Age
    
    person
