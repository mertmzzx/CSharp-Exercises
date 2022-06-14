using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            switch (product)
            {
                case "coffee":
                    Coffee(quantity);
                    break;
                case "water":
                    Water(quantity);
                    break;
                case "coke":
                    Coke(quantity);
                    break;
                default:
                    Snacks(quantity);
                    break;
            }
        }

        static void Coffee(int quantity)
        {
            Console.WriteLine($"{quantity*1.5:F2}");
        }

        static void Water(int quantity)
        {
            Console.WriteLine($"{quantity*1:F2}");
        }

        static void Coke(int quantity)
        {
            Console.WriteLine($"{quantity * 1.4:F2}");
        }

        static void Snacks(int quantity)
        {
            Console.WriteLine($"{quantity * 2:F2}");
        }
    }
}
