using System;
using System.Linq;

namespace Problem_11___Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            char[] separators = { ' ', ',' };
            int[] attacks = Console.ReadLine().Split(separators).Select(int.Parse).ToArray();

            int firstShips = 0;
            int secondShips = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currRowElements = Console.ReadLine().Replace(" ", String.Empty).ToCharArray();

                foreach (var el in currRowElements)
                {
                    if (el == '<')
                    {
                        firstShips++;
                    }
                    else if (el == '>')
                    {
                        secondShips++;
                    }
                }

                for (int col = 0; col < currRowElements.Length; col++)
                {
                    field[row, col] = currRowElements[col];
                }
            }

            int allShips = firstShips + secondShips;
            bool firstWon = false;
            bool secondWon = false;

            for (int i = 0; i < attacks.Length; i += 2)
            {
                int row = attacks[i];
                int col = attacks[i + 1];

                if (row >= 0 && row < size && col >= 0 && col < size)
                {
                    if (field[row, col] == '<')
                    {
                        firstShips--;
                        field[row, col] = 'X';
                    }
                    else if (field[row, col] == '>')
                    {
                        secondShips--;
                        field[row, col] = 'X';
                    }
                    else if (field[row, col] == '#')
                    {
                        MineCoordinates(field, row, col, firstShips, secondShips);
                        int[] shipsCount = CheckShips(field);
                        firstShips = shipsCount[0];
                        secondShips = shipsCount[1];
                    }
                    if (secondShips <= 0)
                    {
                        firstWon = true;
                        break;
                    }
                    if (firstShips <= 0)
                    {
                        secondWon = true;
                        break;
                    }
                    
                }
            }

            int destroyedShips = allShips - (firstShips + secondShips);
            if (firstWon)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (secondWon)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstShips} ships left. Player Two has {secondShips} ships left.");
            }
        }

        private static void MineCoordinates(char[,] field, int row, int col, int firstShips, int secondShips)
        {
            if (ValidateIndexes(field, row - 1, col))
            {
                field[row - 1, col] = 'X';
            }

            if (ValidateIndexes(field, row + 1, col))
            {
                field[row + 1, col] = 'X';
            }

            if (ValidateIndexes(field, row, col - 1))
            {
                field[row, col - 1] = 'X';
            }

            if (ValidateIndexes(field, row, col + 1))
            {
                field[row, col + 1] = 'X';
            }

            if (ValidateIndexes(field, row + 1, col + 1))
            {
                field[row + 1, col + 1] = 'X';
            }

            if (ValidateIndexes(field, row + 1, col - 1))
            {
                field[row + 1, col - 1] = 'X';
            }

            if (ValidateIndexes(field, row - 1, col + 1))
            {
                field[row - 1, col + 1] = 'X';
            }

            if (ValidateIndexes(field, row - 1, col - 1))
            {
                field[row - 1, col - 1] = 'X';
            }
        }
        public static bool ValidateIndexes(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
        public static int[] CheckShips(char[,] field)
        {
            int[] shipsArray = new int[2];
            int playerOneShips = 0;
            int playerTwoShips = 0;

            for (int rowIndex = 0; rowIndex < field.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < field.GetLength(1); colIndex++)
                {
                    if (field[rowIndex, colIndex] == '<')
                    {
                        playerOneShips++;
                    }

                    if (field[rowIndex, colIndex] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }
            shipsArray[0] += playerOneShips;
            shipsArray[1] += playerTwoShips;

            return shipsArray;
        }
    }
}
