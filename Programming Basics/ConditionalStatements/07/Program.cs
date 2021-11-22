using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double speed = double.Parse(Console.ReadLine());

            double time = distance * speed;

            time += Math.Floor(distance / 15) * 12.5;

            double difference = record - time;

            if (difference>0)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {time:F2} seconds.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine($"No, he failed! He was {difference:F2} seconds slower.");
            }

        }
    }
}
