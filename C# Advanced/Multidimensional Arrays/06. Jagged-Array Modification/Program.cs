using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
                jagged[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] token = cmd.Split(' ');
                
                if (token[0] == "Add" || token[0] == "Subtract")
                {
                    int row = int.Parse(token[1]);
                    int col = int.Parse(token[2]);
                    int val = int.Parse(token[3]);

                    if (token[0] == "Subtract")
                        val = -val;
                    if (row >= 0 && row < jagged.Length &&
                        col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += val;
                    }
                    else Console.WriteLine("Invalid coordinates");

                    cmd = Console.ReadLine();
                }
            }
            
            for (int row = 0; row < jagged.Length; row++)
                Console.WriteLine(String.Join(" ", jagged[row]));
        }
    }
}
