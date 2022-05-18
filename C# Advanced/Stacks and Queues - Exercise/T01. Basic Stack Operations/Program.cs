using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Basic_Stack_Operations
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
            Stack<int> stack = new Stack<int>();

            //N --> броят на елементите push
            for (int i = 0; i < n; i++)
            {
                stack.Push(numberList[i]);
            }

            //S --> броят на елементите pop
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            //x --> потърси в стека
            if (stack.Count == 0) //празен стек
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min()); // най-малкия елемент
            }
        }
    }
}
