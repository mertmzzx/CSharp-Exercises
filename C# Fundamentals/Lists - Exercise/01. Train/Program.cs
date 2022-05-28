using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] token = command.Split();
                if (token[0] == "Add")
                {
                    AddWagon(token, wagons);
                }

                if (token.Length < 2)
                {
                    AddPassengers(token, wagons, maxCapacity);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void AddPassengers(string[] token, List<int> wagons, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int passengers = int.Parse(token[0]);
                if (maxCapacity - wagons[i] >= passengers)
                {
                    wagons[i] += passengers;
                    break;
                }

            }
        }

        private static void AddWagon(string[] token, List<int> wagons)
        {
            int number = int.Parse(token[1]);

            wagons.Add(number);
        }
    }
}
