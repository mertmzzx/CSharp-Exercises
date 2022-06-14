using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Problem_5___Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> carsMileage = new Dictionary<string, int>();
            Dictionary<string, int> carsFuel = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split('|');

                string carName = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                carsMileage[carName] = mileage;
                carsFuel[carName] = fuel;
            }

            string[] command = Console.ReadLine().Split(" : ").ToArray();
            while (command[0] != "Stop")
            {
                string carName = command[1];
                
                if (command[0] == "Drive")
                {
                    int distance = int.Parse(command[2]);
                    int fuel = int.Parse(command[3]);

                    if (fuel > carsFuel[carName])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carsMileage[carName] += distance;
                        carsFuel[carName] -= fuel;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (carsMileage[carName] >= 100000)
                    {
                        carsMileage.Remove(carName);
                        Console.WriteLine($"Time to sell the {carName}!");
                    }
                }
                else if (command[0] == "Refuel")
                {
                    int fuel = int.Parse(command[2]);

                    if (carsFuel[carName] + fuel > 75)
                    {
                        Console.WriteLine($"{carName} refueled with {75 - carsFuel[carName]} liters");
                        carsFuel[carName] = 75;
                    }
                    else
                    {
                        carsFuel[carName] += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }

                    
                }
                else if (command[0] == "Revert")
                {
                    int km = int.Parse(command[2]);

                    carsMileage[carName] -= km;

                    if (carsMileage[carName] < 10000)
                    {
                        carsMileage[carName] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {km} kilometers");
                    }
                }

                command = Console.ReadLine().Split(" : ").ToArray();
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", carsMileage
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} -> Mileage: {x.Value} kms, Fuel in the tank: {carsFuel[x.Key]} lt.")));
        }
    }
}
