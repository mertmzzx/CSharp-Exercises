using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzels = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzelsPrice = puzzels * 2.60;
            double talkingDollsPrice = talkingDolls * 3;
            double teddyBearsPrice = teddyBears * 4.10;
            double minionsPrice = minions * 8.20;
            double trucksPrice = trucks * 2;

            double profit = puzzelsPrice + talkingDollsPrice + teddyBearsPrice + minionsPrice + trucksPrice;
            int totalToys = puzzels + talkingDolls + teddyBears + minions + trucks;

            if (totalToys >= 50)
            {
                profit = profit - (profit * 25 / 100);
            }

            profit -= profit * 0.1;


            if (profit >= tripPrice)
            {
                Console.WriteLine($"Yes! {profit-tripPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice-profit:F2} lv needed.");
            }


        }
    }
}
