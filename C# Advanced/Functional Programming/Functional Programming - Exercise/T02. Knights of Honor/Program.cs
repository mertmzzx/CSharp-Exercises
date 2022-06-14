using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Action<string> sir = name => Console.WriteLine("Sir " + name);

            input.ForEach(sir);
        }
    }
}
