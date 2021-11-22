using System;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char previousChart = text[0];

            Console.Write(previousChart);

            for (int i = 1; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (previousChart != currentChar)
                {
                    previousChart = currentChar;
                    Console.Write(previousChart);
                }
            }
        }
    }
}
