using System;

namespace T04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            int rows = int.Parse(input.Split()[0]); 
            int cols = int.Parse(input.Split()[1]); 

            string[,] matrix = new string[rows, cols];
            FillMatrix(matrix);

            string command = Console.ReadLine();

            while (command != "END")
            {
                //"swap row1 col1 row2 col2"
                //1. проверка дали командата е валидна
                //2. проверка дали редове или колоните 
                if (!ValidateCommand(command, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    //валидна команда -> "swap 1 3 4 2"
                    string[] commandParts = command.Split(); //["swap", "1", "3", "4", "2"]
                    int row1 = int.Parse(commandParts[1]); //ред на първия елемент
                    int col1 = int.Parse(commandParts[2]); //колонана първия елемент
                    int row2 = int.Parse(commandParts[3]); //ред на втория елемент
                    int col2 = int.Parse(commandParts[4]);//колона на втория елемент
                    //1. елемента на row1, col1
                    string firstElement = matrix[row1, col1];
                    //2. елемента на row2, col2
                    string secondElement = matrix[row2, col2];
                    //3. размяна
                    //първи -> row2, col2
                    matrix[row2, col2] = firstElement;
                    //втори -> row1, col1
                    matrix[row1, col1] = secondElement;

                    PrintMatrix(matrix);
                }


                command = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        //true -> ако командата е валидна
        //false -> ако командата не е валидна
        private static bool ValidateCommand(string command, int rows, int cols)
        {
            //"swap 1 3 4 2"
            string[] commandParts = command.Split(); //["swap", "1", "3", "4", "2"]
            //1. първата дума е swap
            //2. командата има точно 5 части
            if (commandParts[0] == "swap" && commandParts.Length == 5)
            {
                //валидна команда -> проверка за редове и колони
                int row1 = int.Parse(commandParts[1]);
                int col1 = int.Parse(commandParts[2]);
                int row2 = int.Parse(commandParts[3]);
                int col2 = int.Parse(commandParts[4]);

                if (row1 >= 0 && row1 < rows
                    && col1 >= 0 && col1 < cols
                    && row2 >= 0 && row2 < rows
                    && col2 >= 0 && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(); //"A B B D".Split() -> ["A", "B", "B", "D"]
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
