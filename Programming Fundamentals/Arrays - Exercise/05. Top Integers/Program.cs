using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int i = 0; i < integers.Length; i++)
            {
                bool isNumberBigger = true;

                for (int j = i + 1; j < integers.Length; j++)
                {

                    if (integers[i] <= integers[j])
                    {
                        isNumberBigger = false;
                    }
                }

                if (isNumberBigger)
                {
                    Console.Write($"{integers[i]} ");
                }
            }

        }
    }
}
