using System;
using System.Collections.Generic;
using System.Linq;

namespace T08._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers = new List<int>();

            for (int num = 1; num <= n; num++)
            {
                numbers.Add(num);
            }

            List<int> printNumbers = new List<int>();

            foreach (var num in numbers)
            {
                bool isDiv = true;

                foreach (var div in dividers)
                {
                    Predicate<int> isDivisible = num => num % div == 0;
                    if (!isDivisible(num))
                    {
                        isDiv = false;
                        break;
                    }
                }

                if (isDiv)
                {
                    printNumbers.Add(num);
                }
            }

            Console.WriteLine(String.Join(" ", printNumbers));
        }
    }
}
