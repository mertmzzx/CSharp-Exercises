using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car c = new Car();
            Console.WriteLine(c.WhoAmI());
            Console.WriteLine();

            Car shkoda = new Car("Shkoda", "Felicia", 1999);
            Console.WriteLine(shkoda.WhoAmI());
            Console.WriteLine();

            Car car = new Car();
            car.Make = "BMW";
            car.Model = "X6";
            car.Year = 2022;
            car.FuelQuantity = 50;
            car.FuelConsumption = 0.07;

            Car anotherCar = new Car()
            {
                Make = "Toyota",
                Model = "Avensis",
                Year = 2018,
                FuelQuantity = 40,
                FuelConsumption = 0.08
            };
            Console.WriteLine(anotherCar.WhoAmI());
            Console.WriteLine();

            Console.WriteLine(car.WhoAmI());
            Console.WriteLine();

            car.Drive(700);
            Console.WriteLine(car.WhoAmI());
            Console.WriteLine();

            car.Drive(50);
            Console.WriteLine(car.WhoAmI());
            Console.WriteLine();


            Engine.Run();

            Engine lamboEngine = new Engine(560, 6300);

            Tire[] lamboTires = new Tire[] {
                new Tire(2018, 2.4),
                new Tire(2018, 2.3),
                new Tire(2018, 2.4),
                new Tire(2018, 2.5),
            };

            Car lambo = new Car("Lambo", "Urus", 2010, 250, 0.12, lamboEngine, lamboTires);
            lambo.Drive(50);
            Console.WriteLine(lambo.WhoAmI());
            Console.WriteLine();
        }
    }
}