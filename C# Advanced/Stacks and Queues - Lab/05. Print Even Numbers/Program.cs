using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(elements);
            int count = queue.Count;

            for (int i = 0; i < count; i++)
            {
                if (queue.Peek() % 2 == 1)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
