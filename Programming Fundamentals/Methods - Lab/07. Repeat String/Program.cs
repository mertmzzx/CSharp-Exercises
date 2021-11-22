using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repetition = int.Parse(Console.ReadLine());

            string result = RepeatString(input, repetition);
            Console.WriteLine(result);
        }

        static string RepeatString(string input, int repetition)
        {
            string result = String.Empty;

            for (int i = 0; i < repetition; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
