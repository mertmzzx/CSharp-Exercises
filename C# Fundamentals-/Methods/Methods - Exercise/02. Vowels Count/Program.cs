using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int count = 0;

            int vowels = VowelsCount(input, count);

            Console.WriteLine(vowels);
        }

        static int VowelsCount(string input, int count)
        {
            foreach (var ch in input.ToLower())
            {
                if ("aeiou".Contains(ch))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
