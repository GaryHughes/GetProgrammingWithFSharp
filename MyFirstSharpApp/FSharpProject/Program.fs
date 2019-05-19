// Learn more about F# at http://fsharp.org

open System
open CSharpProject
open System.Collections.Generic

type PersonComparer() =
    interface IComparer<Person> with
        member this.Compare(x, y) = x.Name.CompareTo(y.Name)


[<EntryPoint>]
let main argv =
    
    let tony = Person "Tony"
    tony.PrintName()

    let longhand =
        [ "Tony"; "Fred"; "Samantha"; "Brad"; "Sophie" ]
        |> List.map(fun name -> Person(name))

    let shorthand =
        [ "Tony"; "Fred"; "Samantha"; "Brad"; "Sophie" ]
        |> List.map Person
        

    let pComparer = PersonComparer() :> IComparer<Person>
    pComparer.Compare(Person "Simon", Person "Fred")

   
    let ppComparer =
       { new IComparer<Person> with  
             member this.Compare(x, y) = x.Name.CompareTo(y.Name) } 




    0