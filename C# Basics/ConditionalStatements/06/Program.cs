using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double decor = budget * 10 / 100;
            double clothingMoney = extras * clothingPrice;

            if (extras>150)
            {
                clothingMoney = clothingMoney - (clothingMoney * 10 / 100);
            }

            double difference = budget - (clothingMoney + decor);

            if (difference>=0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {difference:F2} leva left.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {difference:F2} leva more.");
            }
        }
    }
}
