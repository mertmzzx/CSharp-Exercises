using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                leftSum = 0;
                for (int left = i; left > 0; left--)
                {
                    int nextElementPosition = left - 1;
                    if (left > 0)
                    {
                        leftSum += numbers[nextElementPosition];
                    }
                }

                rightSum = 0;
                for (int right = i; right < numbers.Length; right++)
                {
                    int nextElementPosition = right + 1;
                    if (right < numbers.Length - 1)
                    {
                        rightSum += numbers[nextElementPosition];
                    }
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
