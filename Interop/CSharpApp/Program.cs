using System;

namespace CSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Model.Car(4, "Supacars", Tuple.Create(2.0, 4.0));

            var bike = Model.Vehicle.NewMotorbike("CR", 250);

            if (bike.IsMotorbike)
            {
                var motorBike = (Model.Vehicle.Motorbike)bike;
                var engineSize = motorBike.EngineSize;
            }

            var subaru = Model.Functions.CreateCar(4, "Subaru", 2, 4);

            var tesla = Model.Functions.CreateFourWheeledCar.Invoke("Tesla").Invoke(2.0).Invoke(4.0);



        }
    }
}
