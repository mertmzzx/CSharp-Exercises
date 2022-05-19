using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);
            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] line = Console.ReadLine().Split(", ")
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            long maxSum = long.MinValue;
            int bestRow = 0, bestCol = 0;

            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    long sum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine(
                matrix[bestRow, bestCol] + " " +
                matrix[bestRow, bestCol + 1]);
            Console.WriteLine(
                matrix[bestRow + 1, bestCol] + " " +
                matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
