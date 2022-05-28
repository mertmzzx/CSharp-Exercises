using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int seaTrips = int.Parse(Console.ReadLine());
            int mountainTrips = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            double totalPrice = 0.0;
            int totalTrips = 0;

            while (type != "Stop" && totalTrips != seaTrips + mountainTrips)
            {
                if (type == "sea" && seaTrips != 0)
                {
                    seaTrips--;
                    totalPrice += 680;
                }
                else if (type == "mountain" && mountainTrips != 0)
                {
                    mountainTrips--;
                    totalPrice += 499;
                }
                if (totalTrips == seaTrips + mountainTrips)
                {
                    break;
                }
                type = Console.ReadLine();
            }

            if (totalTrips == seaTrips+mountainTrips)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }

            Console.WriteLine($"Profit: {totalPrice} leva.");
        }
    }
}
