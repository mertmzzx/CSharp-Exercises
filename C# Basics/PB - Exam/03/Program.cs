using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            double roomForOnePerson = 18;
            double apartment = 25;
            double presidentApartment = 35;
            double price = 0;
            //double totalPrice = 0;

            switch (room)
            {
                case "room for one person":
                    price = days * roomForOnePerson;
                    break;
                case "apartment":
                    price = days * apartment;

                    if (days < 10)
                    {
                        price = price - (price * 0.3);
                    }
                    else if (10 < days && days < 15)
                    {
                        price = price - (price * 0.35);
                    }
                    else if (days > 15)
                    {
                        price = price - (price * 0.5);
                    }
                    break;
                case "president apartment":
                    price = days * presidentApartment;

                    if (days < 10)
                    {
                        price = price - (price * 0.1);
                    }
                    else if (10 < days && days < 15)
                    {
                        price = price - (price * 0.15);
                    }
                    else if (days > 15)
                    {
                        price = price - (price * 0.2);
                    }
                    break;
            }

            if (rating == "positive")
            {
                price = price + (price * 0.25);
            }
            else if (rating == "negative")
            {
                price = price - (price * 0.1);
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
