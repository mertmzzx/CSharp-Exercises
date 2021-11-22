using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = (int)char.Parse(Console.ReadLine());
            int last = (int)char.Parse(Console.ReadLine());

            if (last < first)
            {
                for (int i = last + 1; i < first; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = first + 1; i < last; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}
