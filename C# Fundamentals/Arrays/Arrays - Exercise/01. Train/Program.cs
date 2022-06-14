using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagons = new int[n];
            int total = 0;

            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                total += wagons[i];
            }
            for (int k = 0; k < wagons.Length; k++)
            {
                Console.Write($"{wagons[k]} ");
            }
            Console.WriteLine();
            Console.WriteLine(total);
            
        }
    }
}
