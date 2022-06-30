using System;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];
            FillMatrix(wall, size);

            int vRow = 0;
            int vCol = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (wall[row, col] == 'V')
                    {
                        vRow = row;
                        vCol = col;
                    }
                }
            }

            wall[vRow, vCol] = '*';
            int countOfHoles = 1;
            int countOfRods = 0;

            bool electrocuted = false;
            string cmd;
            
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (cmd == "up")
                {
                    if (vRow - 1 >= 0)
                    {
                        wall[vRow, vCol] = '*';
                        vRow--;

                        if (wall[vRow, vCol] == 'R')
                        {
                            vRow++;
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vRow, vCol] == 'C')
                        {
                            wall[vRow, vCol] = 'E';
                            electrocuted = true;
                            countOfHoles++;
                            break;
                        }
                        else if (wall[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]");
                        }
                        else if (wall[vRow, vCol] == '-')
                        {
                            wall[vRow, vCol] = '*';
                            countOfHoles++;
                        }
                    }
                }
                else if (cmd == "down")
                {
                    if (vRow + 1 < size)
                    {
                        wall[vRow, vCol] = '*';
                        vRow++;

                        if (wall[vRow, vCol] == 'R')
                        {
                            vRow--;
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vRow, vCol] == 'C')
                        {
                            wall[vRow, vCol] = 'E';
                            electrocuted = true;
                            countOfHoles++;
                            break;
                        }
                        else if (wall[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]");
                        }
                        else if (wall[vRow, vCol] == '-')
                        {
                            wall[vRow, vCol] = '*';
                            countOfHoles++;
                        }
                    }
                }
                else if (cmd == "right")
                {
                    if (vCol + 1 < size)
                    {
                        wall[vRow, vCol] = '*';
                        vCol++;

                        if (wall[vRow, vCol] == 'R')
                        {
                            vCol--;
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vRow, vCol] == 'C')
                        {
                            wall[vRow, vCol] = 'E';
                            electrocuted = true;
                            countOfHoles++;
                            break;
                        }
                        else if (wall[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]");
                        }
                        else if (wall[vRow, vCol] == '-')
                        {
                            wall[vRow, vCol] = '*';
                            countOfHoles++;
                        }
                    }
                }
                else if (cmd == "left")
                {
                    if (vCol - 1 >= 0)
                    {
                        wall[vRow, vCol] = '*';
                        vCol--;

                        if (wall[vRow, vCol] == 'R')
                        {
                            vCol++;
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vRow, vCol] == 'C')
                        {
                            wall[vRow, vCol] = 'E';
                            electrocuted = true;
                            countOfHoles++;
                            break;
                        }
                        else if (wall[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        }
                        else if (wall[vRow, vCol] == '-')
                        {
                            wall[vRow, vCol] = '*';
                            countOfHoles++;
                        }
                    }
                }
            }

            if (!electrocuted)
            {
                wall[vRow, vCol] = 'V';
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }

            PrintMatrix(wall, size);
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
    }
}