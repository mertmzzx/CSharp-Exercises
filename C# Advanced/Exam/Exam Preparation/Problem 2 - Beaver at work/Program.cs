using System;
using System.Collections.Generic;
using System.Linq;

class BeaversAtWork
{
    static void Main()
    {
        // Read the matrix
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = ReadMatrix(n);

        (int row, int col) = FindBeaberLocation(matrix);

        int totalBranchesCount = CalcTotalBranchesCount(matrix);

        // Process the input commands
        Stack<char> branches = new Stack<char>();
        int branchesLeft = totalBranchesCount;
        int branchesOnTheBeach = 0;
        while (true)
        {
            if (branchesLeft == 0)
                break;

            string command = Console.ReadLine();
            if (command == "end")
                break;

            if (command == "up")
                MoveTo(row - 1, col, command);
            else if (command == "down")
                MoveTo(row + 1, col, command);
            else if (command == "left")
                MoveTo(row, col - 1, command);
            else if (command == "right")
                MoveTo(row, col + 1, command);
            else
                throw new Exception("Invalid command: " + command);
        }

        if (branchesLeft == 0)
        {
            string branchesList = string.Join(", ", branches.Reverse());
            Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {branchesList}.");
        }
        else
        {
            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeft} branches left.");
        }
        PrintMatrix(matrix);

        void MoveTo(int newRow, int newCol, string dir)
        {
            // Outside of the pond
            if (newRow < 0 || newRow >= n ||
                newCol < 0 || newCol >= n)
            {
                // Move branch outside of the pond --> throw the last branch (if exists)
                if (branches.Count > 0)
                {
                    branches.Pop();
                    branchesOnTheBeach++;
                }
                return;
            }

            // On a branch
            if (char.IsLower(matrix[newRow, newCol]))
            {
                // Collect the branch
                branches.Push(matrix[newRow, newCol]);
                branchesLeft--;
                matrix[row, col] = '-';
                matrix[newRow, newCol] = 'B';
                row = newRow;
                col = newCol;
                return;
            }

            // On a fish
            if (matrix[newRow, newCol] == 'F')
            {
                // Eat the fish, move to new location (and collect the branch if any)
                matrix[newRow, newCol] = '-'; // Remove the fish
                matrix[row, col] = '-'; // Remove the beaver
                if (dir == "up")
                {
                    if (newRow != 0)
                        newRow = 0;
                    else
                        newRow = n - 1;
                }
                if (dir == "down")
                {
                    if (newRow != n - 1)
                        newRow = n - 1;
                    else
                        newRow = 0;
                }
                if (dir == "left")
                {
                    if (newCol != 0)
                        newCol = 0;
                    else
                        newCol = n - 1;
                }
                if (dir == "right")
                {
                    if (newCol != n - 1)
                        newCol = n - 1;
                    else
                        newCol = 0;
                }
                if (char.IsLower(matrix[newRow, newCol]))
                {
                    // Collect the branch
                    branches.Push(matrix[newRow, newCol]);
                    branchesLeft--;
                }
                matrix[newRow, newCol] = 'B';
                row = newRow;
                col = newCol;
                return;
            }

            // Otherwise
            //if (matrix[newRow, newCol] == '-')
            {
                // Move to the new position
                matrix[row, col] = '-';
                matrix[newRow, newCol] = 'B';
                row = newRow;
                col = newCol;
                return;
            }
        }
    }

    static char[,] ReadMatrix(int n)
    {
        var matrix = new char[n, n];
        for (int row = 0; row < n; row++)
        {
            string[] rowChars = Console.ReadLine().Split(" ").ToArray();
            for (int col = 0; col < n; col++)
                matrix[row, col] = rowChars[col][0];
        }

        return matrix;
    }

    static (int row, int col) FindBeaberLocation(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                    return (row, col);
            }
        }
        throw new Exception("Bearber not found in the matrix!");
    }

    static int CalcTotalBranchesCount(char[,] matrix)
    {
        int branchesCount = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (char.IsLower(matrix[row, col]))
                    branchesCount++;
            }
        }
        return branchesCount;
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col > 0)
                    Console.Write(" ");
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}