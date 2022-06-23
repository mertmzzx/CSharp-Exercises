using System;

namespace Problem_8___The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] map = new char[size, size];

            FillMatrix(map, size);
            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (map[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
            map[armyRow, armyCol] = '-';

            bool win = false;
            while (!win)
            {
                string[] command = Console.ReadLine().Split();
                string direction = command[0];
                int orcRow = int.Parse(command[1]);
                int orcCol = int.Parse(command[2]);
                map[orcRow, orcCol] = 'O';

                switch (direction)
                {
                    case "up":
                        if (armyRow - 1 >= 0)
                        {
                            armyRow--;
                        }
                        break;
                    case "down":
                        if (armyRow + 1 < size)
                        {
                            armyRow++;
                        }
                        break;
                    case "right":
                        if (armyCol + 1 < size)
                        {
                            armyCol++;
                        }
                        break;
                    case "left":
                        if (armyCol - 1 >= 0)
                        {
                            armyCol--;
                        }
                        break;
                }
                armor--;

                if (map[armyRow, armyCol] == 'O')
                {
                    armor -= 2;
                    map[armyRow, armyCol] = '-';
                }

                if (armor <= 0)
                {
                    map[armyRow, armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                if (map[armyRow, armyCol] == 'M')
                {
                    win = true;
                    map[armyRow, armyCol] = '-';
                }
            }

            if (win)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }

            PrintMatrix(map, size);
        }

        public static void PrintMatrix(char[,] map, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(map[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void FillMatrix(char[,] map, int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] currRowElements = Console.ReadLine().Replace(" ", String.Empty).ToCharArray();

                for (int col = 0; col < currRowElements.Length; col++)
                {
                    map[row, col] = currRowElements[col];
                }
            }
        }
    }
}
