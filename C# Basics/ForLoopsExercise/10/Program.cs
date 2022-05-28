using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; 7 <= 997; i++)
            {
                int a = 7;
                int b = i % 10;

                if (a == b)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
