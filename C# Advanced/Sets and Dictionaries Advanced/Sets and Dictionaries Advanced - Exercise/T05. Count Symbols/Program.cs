using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            foreach (char el in text)
            {
                if (!symbols.ContainsKey(el))
                {
                    symbols.Add(el, 0);
                }
                symbols[el]++;
            }

            foreach (var el in symbols)
            {
                Console.WriteLine($"{el.Key}: {el.Value} time/s");
            }
        }
    }
}
