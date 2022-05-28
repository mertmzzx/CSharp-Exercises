using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            
            string sport = "";
            string result = "";

            double winnings = 0.0;
            double totalMoney = 0.0;
            int wins = 0;
            int loses = 0;
            int daywinners = 0;
            int daylosers = 0;

            for (int i = 1; i <= days; i++)
            {
                sport = Console.ReadLine();

                while (sport != "Finish")
                {
                    result = Console.ReadLine();

                    if (result == "win")
                    {
                        wins++;
                        winnings += 20;
                    }
                    else
                    {
                        loses++;
                    }

                    sport = Console.ReadLine();
                }
                if (wins > loses)
                {
                    daywinners++;
                    winnings = winnings * 1.1;
                }
                else
                {
                    daylosers++;
                }
                totalMoney += winnings;

                winnings = 0.0;
                loses = 0;
                wins = 0;
            }

            if (daywinners > daylosers)
            {
                totalMoney = totalMoney * 1.2;

                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:F2}");
            }
        }
    }
}
