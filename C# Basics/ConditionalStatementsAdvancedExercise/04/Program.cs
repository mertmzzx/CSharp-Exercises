using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double rent = 0.0;

            if (season == "Spring")
            {
                rent = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                rent = 4200;
            }
            else
            {
                rent = 2600;
            }
 
            if (fishermen <= 6)
            {
                rent = rent - rent * 0.1;
            }
            else if (7 <= fishermen && fishermen <= 11)
            {
                rent = rent - rent * 0.15;
            }
            else
            {
                rent = rent - rent * 0.25;
            }


            if ((fishermen % 2 == 0) && !(season == "Autumn"))
            {
                rent = rent - rent * 0.05;
            }

            if (budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget - rent:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rent - budget:F2} leva.");
            }
        }
    }
}