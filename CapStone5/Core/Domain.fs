namespace Core

module Domain =

    open System

    type Customer =  
        {   Name : string   }

    type Account =
        {   AccountId : System.Guid; 
            Owner : Customer; 
            Balance : decimal   }

    type CreditAccount = CreditAccount of Account

    type RatedAccount =
        | InCredit of CreditAccount
        | Overdrawn of Account
        member this.Balance =
            match this with
            | InCredit (CreditAccount account) -> account.Balance
            | Overdrawn account -> account.Balance

    type Transaction =
        {   Operation : string
            Amount : decimal
            Timestamp : DateTime    }
      