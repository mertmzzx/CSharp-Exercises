using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] symbols = new char[n, n];
            FillMatrix(symbols);

            bool isFound = false;

            char ch = char.Parse(Console.ReadLine());
            int symbolInInteger = ch;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (symbols[row, col] == ch)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        return;
                    }
                }
            }

            if (isFound == false)
            {
                Console.WriteLine($"{ch} does not occur in the matrix");
            }
        }

        private static void FillMatrix(char[,] symbols)
        {
            for (int row = 0; row < symbols.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToArray();
                for (int col = 0; col < symbols.GetLength(1); col++)
                {
                    symbols[row, col] = rowData[col];
                }
            }
        }
    }
}
