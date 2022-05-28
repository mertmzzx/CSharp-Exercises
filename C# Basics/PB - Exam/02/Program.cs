using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double dailyMoney = double.Parse(Console.ReadLine());
            double earnings = double.Parse(Console.ReadLine());
            double razhodi = double.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());
            double totalMoney = 0.0;

            earnings = earnings * 5;
            dailyMoney = dailyMoney * 5;

            totalMoney = (earnings + dailyMoney) - razhodi;

            if (totalMoney > giftPrice)
            {
                Console.WriteLine($"Profit: {totalMoney:F2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {giftPrice - totalMoney:F2} BGN.");
            }
        }
    }
}
