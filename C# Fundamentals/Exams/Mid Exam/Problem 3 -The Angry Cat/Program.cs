using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3__The_Angry_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ratings = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            string type = Console.ReadLine();

            if (type == "cheap")
            {
                for (int i = entryPoint - 1; i >= 0; i--)
                {
                    if (ratings[i] < ratings[entryPoint])
                    {
                        leftSum += ratings[i];
                    }
                }

                for (int i = entryPoint + 1; i < ratings.Length; i++)
                {
                    if (ratings[i] < ratings[entryPoint])
                    {
                        rightSum += ratings[i];
                    }
                }
            }
            else
            {
                for (int i = entryPoint - 1; i >= 0; i--)
                {
                    if (ratings[i] >= ratings[entryPoint])
                    {
                        leftSum += ratings[i];
                    }
                }

                for (int i = entryPoint + 1; i < ratings.Length; i++)
                {
                    if (ratings[i] >= ratings[entryPoint])
                    {
                        rightSum += ratings[i];
                    }
                }
            }

            if (leftSum >= rightSum)
            {

                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
            
        }
    }
}
