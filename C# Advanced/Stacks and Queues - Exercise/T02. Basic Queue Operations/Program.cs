using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = numbers[0];
            int s = numbers[1];
            int x = numbers[2];

            List<int> numberList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Queue<int> queue = new Queue<int>();

            //N --> броят на елементите enqueue
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numberList[i]);
            }

            //S --> броят на елементите dequeue
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            //x --> потърси в стека
            if (queue.Count == 0) //празна опашка
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min()); // най-малкия елемент
            }
        }
    }
}
