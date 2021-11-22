using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int collums = int.Parse(Console.ReadLine());
            double income = 0;

            if (type == "Premiere")
            {
                income = rows * collums * 12;
            }
            else if (type == "Normal")
            {
                income = rows * collums * 7.50;
            }
            else if (type == "Discount")
            {
                income = rows * collums * 5;
            }

            Console.WriteLine($"{income:F2}");
        }
    }
}
