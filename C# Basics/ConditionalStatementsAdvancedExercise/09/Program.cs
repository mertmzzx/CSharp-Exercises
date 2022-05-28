using System;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double saturdayGames = 0;
            double sundayGames = 0;
            double holidayGames = 0;
            double totalGames = 0;
            double yearGames = 0;


            switch (year)
            {
                case "leap":
                saturdayGames = (48 - h) * 0.75; ;
                sundayGames = h;
                holidayGames = p * 2/3;

                totalGames = saturdayGames + sundayGames + holidayGames;

                double leapGames = totalGames * 0.15;

                yearGames = totalGames + leapGames;

                Console.WriteLine(Math.Floor(yearGames));
                    break;
                case "normal":
                saturdayGames = (48 - h) * 0.75;
                sundayGames = h;
                holidayGames = p * 2/3;

                totalGames = saturdayGames + sundayGames + holidayGames;

                Console.WriteLine(Math.Floor(totalGames));
                    break;
            }
        }
    }
}
