using System;

namespace _01._Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
