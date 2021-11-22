using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTriangle(int.Parse(Console.ReadLine()));
        }

        static void PrintTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                PrintTriangleLine(i);

                Console.WriteLine();
            }

            for (int i = n - 1; i > 0; i--)
            {
                PrintTriangleLine(i);

                Console.WriteLine();
            }
        }

        static void PrintTriangleLine(int line)
        {
            for (int j = 1; j <= line; j++)
            {
                Console.Write($"{j} ");
            }
        }
    }
}
