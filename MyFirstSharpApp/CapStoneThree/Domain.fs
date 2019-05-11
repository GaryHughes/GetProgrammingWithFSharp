module Domain

open System

type Customer =  
    {   Name : string   }

type Account =
    {   AccountId : System.Guid; 
        Owner : Customer; 
        Balance : decimal   }

type Transaction =
    {   Operation : string
        Amount : decimal
        Accepted : bool
        Timestamp : DateTime    }
      