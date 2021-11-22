using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //09. Volleyball

            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double saturdayGames = 0;
            double sundayGames = 0;
            double holidayGames = 0;
            double totalGames = 0;
         
            saturdayGames = (48 - h) * 3.0 / 4; ;
            sundayGames = h;
            holidayGames = p * 2.0 / 3;

            totalGames = saturdayGames + sundayGames + holidayGames;

            if (year == "leap")
            {
                double leapGames = totalGames * 0.15;

                double yearGames = totalGames + leapGames;

                Console.WriteLine(Math.Floor(yearGames));
            }
            else
            {
                Console.WriteLine(Math.Floor(totalGames));
            }
        }
    }
}