using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
