using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            SortedDictionary<double, int> times = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!times.ContainsKey(numbers[i]))
                {
                    times.Add(numbers[i], 0);
                }

                times[numbers[i]]++;
            }

            foreach (var item in times)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
