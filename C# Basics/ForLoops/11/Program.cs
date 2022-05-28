using System;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double laundryPrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            int toys = 0;
            double totalMoney = 0;
            int evenAgeSavings = 1;

            for (int i = 1; i <= age; i++)
            {  

                if (i % 2 == 0)
                {
                    totalMoney += (10 * evenAgeSavings++) - 1;
                }
                else
                {
                    toys += 1;
                }
            }

            toysPrice *= toys;
            totalMoney += toysPrice;

            if (totalMoney >= laundryPrice)
            {
                Console.WriteLine($"Yes! {totalMoney-laundryPrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {laundryPrice-totalMoney:F2}");
            }
        }
    }
}
