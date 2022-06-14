using System;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char middle = char.Parse(Console.ReadLine());
            char last = char.Parse(Console.ReadLine());

            Console.WriteLine($"{last} {middle} {first}");
        }
    }
}
