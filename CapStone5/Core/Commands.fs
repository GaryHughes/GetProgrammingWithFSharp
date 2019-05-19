namespace Core

module Commands =

    type BankOperation = Deposit | Withdraw
    type Command = AccountCommand of BankOperation | Exit

    let tryParseCommand (cmd:char) : Option<Command> =
        match cmd with
        | 'w' -> Some((Command.AccountCommand)BankOperation.Withdraw) 
        | 'd' -> Some((Command.AccountCommand)BankOperation.Deposit)
        | 'x' -> Some(Command.Exit)
        | _ -> None

    let tryGetBankOperation cmd =
        match cmd with
        | Exit -> None
        | AccountCommand op -> Some op



