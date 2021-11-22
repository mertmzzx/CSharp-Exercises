using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
