using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double coffee = 0;
            double water = 0;
            double beer = 0;
            double sweets = 0;
            double peanuts = 0;

            switch (city)
            {
                case "Sofia":
                    if (product == "coffee")
                    {
                        coffee = quantity * 0.50;
                        Console.WriteLine(coffee);
                    }
                    else if (product == "water")
                    {
                        water = quantity * 0.80;
                        Console.WriteLine(water);
                    }
                    else if (product == "beer")
                    {
                        beer = quantity * 1.20;
                        Console.WriteLine(beer);
                    }
                    else if (product == "sweets")
                    {
                        sweets = quantity * 1.45;
                        Console.WriteLine(sweets);
                    }
                    else if (product == "peanuts")
                    {
                        peanuts = quantity * 1.60;
                        Console.WriteLine(peanuts);
                    }
                    break;
                case "Plovdiv":
                    if (product == "coffee")
                    {
                        coffee = quantity * 0.40;
                        Console.WriteLine(coffee);
                    }
                    else if (product == "water")
                    {
                        water = quantity * 0.70;
                        Console.WriteLine(water);
                    }
                    else if (product == "beer")
                    {
                        beer = quantity * 1.15;
                        Console.WriteLine(beer);
                    }
                    else if (product == "sweets")
                    {
                        sweets = quantity * 1.30;
                        Console.WriteLine(sweets);
                    }
                    else if (product == "peanuts")
                    {
                        peanuts = quantity * 1.50;
                        Console.WriteLine(peanuts);
                    }
                    break;
                case "Varna":
                    if (product == "coffee")
                    {
                        coffee = quantity * 0.45;
                        Console.WriteLine(coffee);
                    }
                    else if (product == "water")
                    {
                        water = quantity * 0.70;
                        Console.WriteLine(water);
                    }
                    else if (product == "beer")
                    {
                        beer = quantity * 1.10;
                        Console.WriteLine(beer);
                    }
                    else if (product == "sweets")
                    {
                        sweets = quantity * 1.35;
                        Console.WriteLine(sweets);
                    }
                    else if (product == "peanuts")
                    {
                        peanuts = quantity * 1.55;
                        Console.WriteLine(peanuts); ;
                    }
                    break;
            }


        }
    }
}
