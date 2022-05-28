using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int extractedSpice = 0;

            if (yield < 100)
            {
                Console.WriteLine(days);
                Console.WriteLine(extractedSpice);
            }
            else
            {
                while (yield >= 100)
                {
                    extractedSpice += yield - 26;
                    yield -= 10;
                    days++;
                }

                extractedSpice -= 26;

                Console.WriteLine(days);
                Console.WriteLine(extractedSpice);
            }
        }
    }
}
