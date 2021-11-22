using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double spentMoney = 0.0;
            string destination = "";
            string vacation = "";

            switch (season)
            {
                case "summer":
                    if (budget <= 100)
                    {
                        spentMoney = budget * 0.3;
                        destination = "Bulgaria";
                        vacation = "Camp";
                    }
                    else if (budget <= 1000)
                    {
                        spentMoney = budget * 0.4;
                        destination = "Balkans";
                        vacation = "Camp";
                    }
                    else
                    {
                        spentMoney = budget * 0.9;
                        destination = "Europe";
                        vacation = "Hotel";
                    }
                    break;
                case "winter":
                    if (budget <= 100)
                    {
                        spentMoney = budget * 0.7;
                        destination = "Bulgaria";
                        vacation = "Hotel";
                    }
                    else if (budget <= 1000)
                    {
                        spentMoney = budget * 0.8;
                        destination = "Balkans";
                        vacation = "Hotel";
                    }
                    else
                    {
                        spentMoney = budget * 0.9;
                        destination = "Europe";
                        vacation = "Hotel";
                    }
                    break;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{vacation} - {spentMoney:F2}");
        }
    }
}
