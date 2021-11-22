using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double tripPrice = 0.0;
            double currentSavings = 0.0;

            while (destination != "End")
            {
                tripPrice = double.Parse(Console.ReadLine());

                while (currentSavings < tripPrice)
                {
                    currentSavings += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");

                currentSavings = 0;

                destination = Console.ReadLine();
            }

        }
    }
}
