using System;
using System.Linq;

namespace T03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = n[0];
            int cols = n[1];
            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);
            int Sum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 2 < rows && col + 2 < cols)
                    {
                        int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                      matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                      matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                        if (currSum > Sum)
                        {
                            Sum = currSum;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"Sum = {Sum}");

            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
