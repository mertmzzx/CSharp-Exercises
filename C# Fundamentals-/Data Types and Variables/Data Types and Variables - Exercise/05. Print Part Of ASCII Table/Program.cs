using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            while (n <= n2)
            {
                string asciiChar = Convert.ToChar(n).ToString();

                Console.Write($"{asciiChar} ");

                n++;
            }      
        }
    }
}
