using System;

namespace T05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();       
            int rows = int.Parse(input.Split()[0]);  
            int cols = int.Parse(input.Split()[1]);  

            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int index = 0; // обхождане на snake

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    //четен ред -> от първа колона към последна
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[index];
                        index++;
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    //нечетен ред -> от последна колона към първа
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[index];
                        index++;
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
            }

            PrintMatrix(matrix);

        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
