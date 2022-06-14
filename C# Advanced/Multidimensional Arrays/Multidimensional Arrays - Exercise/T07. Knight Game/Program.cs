using System;
using System.Linq;

namespace T07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            FillMatrix(matrix);

            int knight = 0;

            while (true)
            {
                int rowIndexKnight = -1;
                int colIndexKnight = -1;

                int attacks = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currAtt = CurrentAttack(matrix, row, col);

                            if (currAtt > attacks)
                            {
                                attacks = currAtt;
                                rowIndexKnight = row;
                                colIndexKnight = col;
                            }
                        }
                    }
                }

                if (attacks > 0)
                {
                    matrix[rowIndexKnight, colIndexKnight] = '0';
                    knight++;
                }
                else break;
            }

            Console.WriteLine(knight);
        }

        private static int CurrentAttack(char[,] matrix, int row, int col)
        {
            int numberAttacks = 0;

            if (IsValid(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
            {
                numberAttacks++;
            }
            if (IsValid(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
            {
                numberAttacks++;
            }

            return numberAttacks;
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        private static bool IsValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
