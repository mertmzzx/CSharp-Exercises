using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int current = 1;
            bool stop = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write(current + " ");
                    current++;

                    if (current > n)
                    {
                        stop = true;
                        break;
                    }
                }

                Console.WriteLine();

                if (stop)
                {
                    break;
                }
            }
        }   
    }
}
