
type CustomerId = CustomerId of string
type Email = Email of string
type Telephone = Telephone of string
type Address = Address of string

type Customer =
    { CustomerId : CustomerId
      Email : Email
      Telephone : Telephone
      Address : Address }

let createCustomer (customerId:CustomerId) (email:Email) (telephone:Telephone) (address:Address) =
    { CustomerId = customerId
      Email = email
      Telephone = telephone
      Address = address }







