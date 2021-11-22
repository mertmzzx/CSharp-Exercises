using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < items.Length / 2; i++)
            {
                string temp = items[i];
                items[i] = items[items.Length - i - 1];
                items[items.Length - 1 - i] = temp;
            }

            Console.WriteLine(string.Join(" ", items));
        }
    }
}
