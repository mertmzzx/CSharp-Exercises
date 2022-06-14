using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();

                if (cmd.StartsWith("1"))
                {
                    int num = int.Parse(cmd.Split()[1]);

                    numbers.Push(num);
                }
                else if (cmd == "2")
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (cmd == "3")
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
                else
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
