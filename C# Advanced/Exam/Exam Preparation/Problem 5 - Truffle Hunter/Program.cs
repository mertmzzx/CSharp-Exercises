using System;

namespace Problem_5___Truffle_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];

            FillMatrix(forest, size);

            string cmd;
            int sTruffels = 0;
            int wTruffels = 0;
            int bTruffels = 0;
            int eatenTruffels = 0; 

            while ((cmd = Console.ReadLine()) != "Stop the hunt")
            {
                string action = cmd.Split()[0];
                int row = int.Parse(cmd.Split()[1]);
                int col = int.Parse(cmd.Split()[2]);

                if (action == "Collect")
                {
                    char truffel = forest[row, col];
                    forest[row, col] = '-';

                    if (truffel == 'S') sTruffels++;
                    else if (truffel == 'W') wTruffels++;
                    else if (truffel == 'B') bTruffels++;
                }
                else
                {
                    string direction = cmd.Split()[3];

                    switch (direction)
                    {
                        case "up":
                            while (IsValidRow(row, size))
                            {
                                if (IsEating(row, col, forest))
                                {
                                    eatenTruffels++;
                                }

                                row -= 2;
                            }
                            break;
                        case "down":
                            while (IsValidRow(row, size))
                            {
                                if (IsEating(row, col, forest))
                                {
                                    eatenTruffels++;
                                }

                                row += 2;
                            }
                            break;
                        case "right":
                            while (IsValidCol(col, size))
                            {
                                if (IsEating(row, col, forest))
                                {
                                    eatenTruffels++;
                                }

                                col += 2;
                            }
                            break;
                        case "left":
                            while (IsValidCol(col, size))
                            {
                                if (IsEating(row, col, forest))
                                {
                                    eatenTruffels++;
                                }

                                col -= 2;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {bTruffels} black, {sTruffels} summer, and {wTruffels} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffels} truffles.");
            PrintMatrix(forest, size);
        }

        public static void FillMatrix(char[,] forest, int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] currRowElements = Console.ReadLine().Replace(" ", String.Empty).ToCharArray();

                for (int col = 0; col < currRowElements.Length; col++)
                {
                    forest[row, col] = currRowElements[col];
                }
            }
        }

        private static void PrintMatrix(char[,] forest, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsEating(int row, int col, char[,] forest)
        {
            char sym = forest[row, col];

            if (sym == 'S' || sym == 'W' || sym == 'B')
            {
                forest[row, col] = '-';
                return true;
            }

            return false;
        }

        public static bool IsValidRow(int row, int size)
        {
            return row >= 0 && row < size;
        }

        public static bool IsValidCol(int col, int size)
        {
            return col >= 0 && col < size;
        }
    }
}
