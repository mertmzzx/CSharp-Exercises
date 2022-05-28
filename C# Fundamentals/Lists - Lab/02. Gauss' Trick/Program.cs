using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<int> list = input.Select(int.Parse).ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {
                list[0 + i] += list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
