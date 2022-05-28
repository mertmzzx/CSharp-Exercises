using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Coffee_Lover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();

            int numberComm = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberComm; i++)
            {
                string command = Console.ReadLine();

                string[] token = command.Split();

                if (token[0] == "Include")
                {
                    string coffee = token[1];
                    coffees.Add(coffee);
                }
                else if (token[0] == "Remove")
                {
                    RemoveCoffee(coffees, token);

                }
                else if (token[0] == "Prefer")
                {
                    PreferCoffee(coffees, token);
                }
                else if (token[0] == "Reverse")
                {
                    coffees.Reverse();
                }
            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }

        private static void PreferCoffee(List<string> coffees, string[] token)
        {
            int coffeeIndex1 = int.Parse(token[1]);
            int coffeeIndex2 = int.Parse(token[2]);

            if (coffeeIndex1 >= 0 && coffeeIndex1 < coffees.Count && coffeeIndex2 >= 0 && coffeeIndex2 < coffees.Count)
            {
                string temp = coffees[coffeeIndex1];
                coffees[coffeeIndex1] = coffees[coffeeIndex2];
                coffees[coffeeIndex2] = temp;
            }
        }

        private static void RemoveCoffee(List<string> coffees, string[] token)
        {
            int number = int.Parse(token[2]);

            if (token[1] == "first")
            {
                coffees.RemoveRange(0, number);
            }
            else
            {
                coffees.RemoveRange(coffees.Count - number, number);
            }
        }
    }
}
