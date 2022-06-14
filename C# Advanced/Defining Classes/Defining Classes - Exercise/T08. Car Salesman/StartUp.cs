using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = data[0];
                int power = int.Parse(data[1]);

                Engine engine = new Engine(model, power);

                if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = data[2];
                    }
                }
                else if (data.Length == 4)
                {
                    int displacement = int.Parse(data[2]);
                    string eff = data[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = eff;
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = data[0];

                Engine engine = engines.First(x => x.Model == data[1]);
                Car car = new Car(model, engine);

                if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = data[2];
                    }
                }
                else if (data.Length == 4)
                {
                    int weight = int.Parse(data[2]);
                    string color = data[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
