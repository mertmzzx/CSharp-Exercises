using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            Action<List<int>> Reverse = i =>
            {
                for (int j = 0; j < i.Count / 2; j++)
                {
                    int temp = i[j];
                    i[j] = i[i.Count - 1 - j];
                    i[i.Count - 1 - j] = temp;
                }
            };
            Reverse(numbers);

            Predicate<int> filter = numbers => numbers % n != 0;

            Console.WriteLine(string.Join(" ", numbers.FindAll(filter)));
        }
    }
}
