using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> filter = names => names.Length <= length;
            Console.WriteLine(string.Join(Environment.NewLine, names.FindAll(filter)));
        }
    }
}
