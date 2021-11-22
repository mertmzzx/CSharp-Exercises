using System;
using System.Linq;

namespace ReadingOnOneLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5 6 7 1 2 3
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] = {array[i]}");
            }

            //string line = Console.ReadLine();
            //string[] arr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //
            //int[] numArr = new int[arr.Length];
            //
            //for (int i = 0; i < numArr.Length; i++)
            //{
            //    numArr[i] = int.Parse(arr[i]);
            //}
        }
    }
}
