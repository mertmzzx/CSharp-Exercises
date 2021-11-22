using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();

            List<int> list1 = input1.Select(int.Parse).ToList();
            List<int> list2 = input2.Select(int.Parse).ToList();
            List<int> mergedList = new List<int>();

            int longerList = 0;

            if (list1.Count > list2.Count)
            {
                longerList += list1.Count;
            }
            else
            {
                longerList += list2.Count;
            }

            for (int i = 0; i < longerList; i++)
            {
                if (list1.Count > i)
                {
                    mergedList.Add(list1[i]);
                }

                if (list2.Count > i)
                {
                    mergedList.Add(list2[i]);
                }
            }

            Console.WriteLine(String.Join(" ", mergedList));
        }
    }
}
