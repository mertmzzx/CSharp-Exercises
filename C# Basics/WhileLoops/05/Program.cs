using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string deposit = Console.ReadLine();
            double total = 0.0;

            while (deposit != "NoMoreMoney")
            {
                double currentIncrease = double.Parse(deposit);

                if (currentIncrease < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                total += currentIncrease;
                Console.WriteLine($"Increase: {currentIncrease:F2}");

                deposit = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
