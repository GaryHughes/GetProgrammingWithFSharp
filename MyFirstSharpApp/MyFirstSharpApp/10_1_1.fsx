
type Address =
    {   Street : string
        Town : string
        City : string }


type Customer =
    {   Forename : string
        Surname : string
        Age : int
        Address : Address
        EmailAddress : string }

let customer = 
    {   Forename = "Joe"
        Surname = "Bloggs"
        Age = 30
        Address =
            {   Street = "The Street"
                Town = "The Town"
                City = "The City" }
        EmailAddress = "joe@bloggs.com" }

let updatedCustomer = 
    {   customer with
            Age = 31
            EmailAddress = "joe@blogs.co.uk" }



let one =  
    {   Street = "The Street"
        Town = "The Town"
        City = "The City" }

let two =
    {   Street = "The Street"
        Town = "The Town"
        City = "The City" }


one = two
one.Equals(two)
System.Object.ReferenceEquals(one, two)

let randomiseAge customer =
    let random = System.Random()
    { customer with Age = random.Next(18, 45) }


let newCustomer = randomiseAge(customer)

customer = newCustomer 



