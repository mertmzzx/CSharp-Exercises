using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int tank = 255;
            int water = 0;

            while (lines > 0)
            {
                int liters = int.Parse(Console.ReadLine());

                if (liters > tank)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else if (water + liters > tank)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    water += liters;
                }


                lines--;
            }

            Console.WriteLine(water);
        }
    }
}
