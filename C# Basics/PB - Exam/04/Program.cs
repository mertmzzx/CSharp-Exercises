using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int computers = int.Parse(Console.ReadLine());
            int rating = 0;
            double totalRatings = 0.0;
            double possibleSales = 0.0;
            double sales = 0.0;
            double totalSales = 0.0;

            for (int i = 1; i <= computers; i++)
            {
                int n = int.Parse(Console.ReadLine());

                rating = n % 10;
                possibleSales = n / 10;

                if (rating == 2)
                {
                    sales = 0;
                }
                else if (rating == 3)
                {
                    sales = possibleSales * 0.5;
                }
                else if (rating == 4)
                {
                    sales = possibleSales * 0.7;
                }
                else if (rating == 5)
                {
                    sales = possibleSales * 0.85;
                }
                else if (rating == 6)
                {
                    sales = possibleSales * 1;
                }

                totalRatings += rating;
                totalSales += sales;
            }

            Console.WriteLine($"{totalSales:F2}");
            Console.WriteLine($"{totalRatings/computers:F2}");
        }
    }
}
