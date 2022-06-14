using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Action<string> print = name => Console.WriteLine(name);

            input.ForEach(print);
        }
    }
}
