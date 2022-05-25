using System;
using System.Collections.Generic;

namespace T02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            int n = int.Parse(input.Split(' ')[0]);
            int m = int.Parse(input.Split(' ')[1]);

            HashSet<int> firstSet = new HashSet<int>(); 
            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> secondSet = new HashSet<int>(); 
            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
