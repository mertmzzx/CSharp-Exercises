using System;
using System.Linq;

namespace Problem_3___Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            int currCupidPosition = 0;
            string cmd = Console.ReadLine();

            while (cmd != "Love!")
            {
                string[] cmdSplited = cmd.Split();
                int jump = int.Parse(cmdSplited[1]);

                if (currCupidPosition + jump >= neighborhood.Length)
                {
                    currCupidPosition = 0;
                }
                else
                {
                    currCupidPosition += jump;
                }

                neighborhood[currCupidPosition] -= 2;

                if (neighborhood[currCupidPosition] == 0)
                {
                    Console.WriteLine($"Place {currCupidPosition} has Valentine's day.");
                }

                if (neighborhood[currCupidPosition] < 0)
                {
                    Console.WriteLine($"Place {currCupidPosition} already had Valentine's day.");
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {currCupidPosition}.");

            if (!neighborhood.Any(number => number > 0))
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Count(number => number > 0)} places.");
            }

        }
    }
}
