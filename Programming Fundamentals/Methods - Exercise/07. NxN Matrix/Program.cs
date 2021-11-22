using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMatrix(n);
        }

        private static void PrintMatrix(int n)
        {
            for (int rows = 0; rows < n; rows++)
            {
                for (int collums = 0; collums < n; collums++)
                {
                    Console.Write($"{n} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
