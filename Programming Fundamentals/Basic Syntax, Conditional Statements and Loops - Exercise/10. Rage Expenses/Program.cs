using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double expenses = 0;

            for (int currentGame = 1; currentGame <= lostGames; currentGame++)
            {
                if (lostGames % 2 == 0)
                {
                    expenses += headsetPrice;
                }
                if (lostGames % 3 == 0)
                {
                    expenses += mousePrice;
                }

                if (currentGame % 6 == 0)
                {
                    expenses += keyboardPrice;
                }

                if (currentGame % 12 == 0)
                {
                    expenses += displayPrice;
                }
            }
            
            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
