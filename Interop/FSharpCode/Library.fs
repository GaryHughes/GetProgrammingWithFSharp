namespace Model

type Car = 
    {   Wheels : int
        Brand : string
        Dimensions : float * float  }

type Vehicle = 
    | MotorCar of Car
    | Motorbike of Name:string * EngineSize:float 

module Functions =
    
    let CreateCar wheels brand x y =
        {   Wheels = wheels; Brand = brand; Dimensions = x,y }

    let CreateFourWheeledCar = CreateCar 4

