using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(elements);
            string cmd = Console.ReadLine().ToLower();

            while (cmd != "end")
            {
                var token = cmd.Split(' ');
                if (token[0] == "add")
                {
                    int n1 = int.Parse(token[1]);
                    int n2 = int.Parse(token[2]);
                    stack.Push(n1);
                    stack.Push(n2);
                }
                else if (token[0] == "remove")
                {
                    int count = int.Parse(token[1]);
                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                cmd = Console.ReadLine();
            }

            var sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
