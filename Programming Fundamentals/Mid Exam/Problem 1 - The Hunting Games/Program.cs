using System;

namespace Problem_1___Burger_Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());
            double totalProfit = 0;

            for (int i = 1; i <= numberOfCities; i++)
            {
                string cityName = Console.ReadLine();
                double income = double.Parse(Console.ReadLine());
                double expenses = double.Parse(Console.ReadLine());

                if (i % 3 == 0 && i % 5 != 0)
                {
                    expenses += expenses * 0.5;
                }
                else if (i % 5 == 0)
                {
                    income *= 0.9;
                }

                double profit = income - expenses;
                totalProfit += profit;

                Console.WriteLine($"In {cityName} Burger Bus earned {profit:f2} leva.");
            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
