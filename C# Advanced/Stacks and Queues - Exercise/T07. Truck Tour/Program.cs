using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                int[] station = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int current = station[0] - station[1];
                queue.Enqueue(current);
            }

            if (queue.Sum() < 0)
            {
                return;
            }

            for (int j = 0; j < n; j++)
            {
                bool hasNotFailed = true;
                long totalFuel = 0;

                foreach (int element in queue)
                {
                    totalFuel += element;
                    if (totalFuel < 0)
                    {
                        hasNotFailed = false;
                        break;
                    }
                }

                if (hasNotFailed)
                {
                    Console.WriteLine(j);
                    break;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }
        }
    }
}
