using System;
using System.Collections.Generic;

namespace T08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expr = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (var item in expr)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (item == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else if (item == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else if (item == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid || stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
