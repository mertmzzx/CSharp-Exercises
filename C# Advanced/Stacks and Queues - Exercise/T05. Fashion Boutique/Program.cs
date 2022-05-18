using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int racks = 1;

            while (clothes.Count > 0)
            {
                if (sum < capacity)
                {
                    if (sum + clothes.Peek() > capacity)
                    {
                        racks++;
                        sum = 0;
                    }
                    else sum += clothes.Pop();
                }
                else if (sum >= capacity)
                {
                    racks++;
                    sum = 0;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
