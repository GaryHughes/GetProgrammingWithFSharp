
type MMCDisk =
| RsMmc
| MmcPlus
| SecureMmc

type Disk =
| HardDisk of RPM:int * Platters:int
| SolidState
| MMC of MMCDisk * NumberOfPins:int

let myHardDisk = HardDisk(RPM=250, Platters=7)
let myHardDiskShort = HardDisk(250, 7)
let args = 250, 7
let myHardDiskTupled = HardDisk args
let myMMC = MMC(RsMmc, 5)
let mySsd = SolidState



let describe disk =
    match disk with
    | SolidState -> printfn "I'm a newfangled SSD."
    | MMC(RsMmc, 1) -> printfn "I have only 1 pin."
    | MMC(RsMmc, pins) when pins < 5 -> printfn "I'm an MMC wtih a few pins."
    | MMC(RsMmc, pins) -> printfn "I'm an MMC with %d pins." pins
    | HardDisk(RPM=5400) -> printfn "I'm a slow hard disk."
    | HardDisk(Platters=7) -> printfn "I have 7 spindles."
    | HardDisk _ -> printfn "I'm a hard disk"


describe mySsd




type DiskInfo =
    {   Manufacturer : string
        SizeGb : int 
        DiskData : Disk }

type Computer = { Manufacturer : string; Disks : DiskInfo list }

let myPc =
    {   Manufacturer = "Computers Inc."
        Disks =
            [ { Manufacturer = "HardDisks Inc."
                SizeGb = 100
                DiskData = HardDisk(5400, 7) }
              { Manufacturer = "SuperDisks Corp."
                SizeGb = 250
                DiskData = SolidState } ] }


