using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<int> list = input.Select(int.Parse).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.Remove(list[i]);
                    i--;
                }
            }

            Reverse(list);

            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }

        static void Reverse(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    min = j;
                    var temp = list[min];
                    list[min] = list[i];
                    list[i] = temp;
                }
            }
        }
    }
}
