module Operations

open Domain
open Auditing

let deposit amount account =
    {   account with Balance = account.Balance + amount }

let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }


