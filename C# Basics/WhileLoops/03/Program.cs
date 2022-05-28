using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                sum += input;

                if (sum >= n)
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
        }
    }
}
