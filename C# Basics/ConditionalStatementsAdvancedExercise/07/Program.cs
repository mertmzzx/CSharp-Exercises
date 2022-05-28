using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartment = 0;
            double priceStudio = 0;
            double priceApartment = 0;


            if (month == "May" || month == "October")
            {
                studio = 50;
                apartment = 65;

                priceStudio = nights * studio;
                priceApartment = nights * apartment;

                if (nights > 7 && nights <= 14)
                {
                    priceStudio -= priceStudio * 0.05;
                }
                else if (nights > 14)
                {
                    priceStudio -= priceStudio * 0.3;
                    priceApartment -= priceApartment * 0.1;
                }
            }
            else if (month == "June" || month == "September")
            {
                studio = 75.20;
                apartment = 68.70;

                priceStudio = nights * studio;
                priceApartment = nights * apartment;


                if (nights > 14)
                {
                    priceStudio -= priceStudio * 0.2;
                    priceApartment -= priceApartment * 0.1;
                }
            }
            else if (month == "July" || month == "August")
            {
                studio = 76;
                apartment = 77;

                priceStudio = nights * studio;
                priceApartment = nights * apartment;

                if (nights > 14)
                {
                    priceApartment -= priceApartment * 0.1;
                }
            }

            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        }
    }
}
