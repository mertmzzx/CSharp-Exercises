using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1;
            Console.WriteLine(number);

            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    number *= 2 * 2;
                    Console.WriteLine(number);
                }
            }
        }
    }
}
