using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var t in secondLine)
            {
                foreach (var j in firstLine)
                {
                    if (t == j)
                    {
                        Console.Write($"{t} ");
                    }
                }
            }
        }
    }
}
