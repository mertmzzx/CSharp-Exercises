using System;
using System.Linq;

namespace T01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //бр. редове = бр. колони

            //1. напълним матрицата
            int[,] numbers = new int[n, n];
            FillMatrix(numbers);

            //2. сума от главния диагонал -> ред == колоната
            int sumPrimaryDiagonal = 0;

            //3. сума от второстпенния диагонал -> ред + колона == n - 1
            int sumSecondaryDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int number = numbers[row, col]; //текущото число

                    if (row == col)
                    {
                        //числото е на главния диагонал
                        sumPrimaryDiagonal += number;
                    }

                    if (row + col == n - 1)
                    {
                        //числото е на второстепенния диагонал
                        sumSecondaryDiagonal += number;
                    }
                }
            }

            //4. абсолютна стойност (сума от главния диагонал - сума от второстпенния диагонал)
            Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));
        }

        private static void FillMatrix(int[,] numbers)
        {
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    numbers[row, col] = rowData[col];
                }
            }
        }
    }
}
