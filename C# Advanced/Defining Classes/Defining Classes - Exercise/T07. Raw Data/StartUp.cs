using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                string model = data.Split()[0];

                int engineSpeed = int.Parse(data.Split()[1]);
                int enginePower = int.Parse(data.Split()[2]);

                int cargoWeight = int.Parse(data.Split()[3]);
                string cargoType = data.Split()[4];

                double tire1Pressure = double.Parse(data.Split()[5]);
                int tire1Age = int.Parse(data.Split()[6]);
                double tire2Pressure = double.Parse(data.Split()[7]);
                int tire2Age = int.Parse(data.Split()[8]);
                double tire3Pressure = double.Parse(data.Split()[9]);
                int tire3Age = int.Parse(data.Split()[10]);
                double tire4Pressure = double.Parse(data.Split()[11]);
                int tire4Age = int.Parse(data.Split()[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age,
                    tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            PrintCars(cars, command);
        }

        private static void PrintCars(List<Car> cars, string command)
        {
            if (command == "fragile")
            {
                List<Car> carsToPrint = cars.Where(x => x.Cargo.Type == command && x.Tires.Any(t => t.Pressure < 1)).ToList();
                foreach (var car in carsToPrint)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                List<Car> carsToPrint = cars.Where(x => x.Cargo.Type == command && x.Engine.Power > 250).ToList();
                foreach (var car in carsToPrint)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}