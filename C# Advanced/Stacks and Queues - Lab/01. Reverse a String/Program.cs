using System;
using System.Collections.Generic;

namespace _01._Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var ch in text)
            {
                stack.Push(ch);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
