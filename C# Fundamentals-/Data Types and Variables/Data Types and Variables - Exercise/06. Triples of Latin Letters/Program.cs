using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char firstChar = (char)('a' + i);

                for (int j = 0; j < n; j++)
                {
                    char secondtChar = (char)('a' + j);

                    for (int k = 0; k < n; k++)
                    {
                        char thirdChar = (char)('a' + k);

                        Console.WriteLine($"{firstChar}{secondtChar}{thirdChar}");
                    }
                }
            }
        }
    }
}