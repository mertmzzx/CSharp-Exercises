using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string direction = cmd.Split(", ")[0];
                string carNumber = cmd.Split(", ")[1];

                if (direction == "IN")
                {
                    if (!cars.Contains(carNumber))
                    {
                        cars.Add(carNumber);
                    }
                }
                else
                {
                    if (cars.Contains(carNumber))
                    {
                        cars.Remove(carNumber);
                    }   
                }

                cmd = Console.ReadLine();
            }

            if (cars.Count > 0 )
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
