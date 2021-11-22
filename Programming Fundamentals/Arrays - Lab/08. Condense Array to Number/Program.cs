using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //int[] condensed = new int[array.Length - 1];
            //
            //if (array.Length == 1)
            //{
            //    Console.WriteLine(array[0]);
            //    return;
            //}
            //
            //for (int i = 0; i < array.Length; i++)
            //{
            //    for (int k = 0; k < condensed.Length - 1; k++)
            //    {
            //        condensed[k] = array[k] + array[k + 1];             
            //    }
            //
            //    array = condensed;
            //}
            //
            //Console.WriteLine(condensed[0

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] condensed = new int[numbers.Length - 1];

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < condensed.Length - i; j++)
                {
                    condensed[j] = numbers[j] + numbers[j + 1];
                }
                numbers = condensed;
            }
            Console.WriteLine(condensed[0]);

        }
    }
}
