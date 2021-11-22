using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            string outfit = "";
            string shoes = "";


            switch (time)
            {
                case "Morning":
                    if (10 <= temp && temp <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (18 < temp && temp <=24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (temp >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (10 <= temp && temp <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < temp && temp <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (temp >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                    if (10 <= temp && temp <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < temp && temp <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (temp >= 25)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    break;
            }

            Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
        }
    }
}
