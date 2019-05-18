
type CustomerId = CustomerId of string

type ContactDetails =
| Address of string
| Telephone of string
| Email of string

type Customer =
    { CustomerId : CustomerId
      PrimaryContactDetails : ContactDetails 
      SecondaryContactDetails : ContactDetails option }

let createCustomer (customerId:CustomerId) (primaryContactDetails:ContactDetails) (secondaryContactDetails:ContactDetails option) =
    { CustomerId = customerId
      PrimaryContactDetails = primaryContactDetails
      SecondaryContactDetails = secondaryContactDetails }

let customer = createCustomer (CustomerId "Fred") (Email "fred@smith.com") (Some(Telephone "123456789"))

let customer2 = createCustomer (CustomerId "Fred") (Email "fred@smith.com") None






