using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int g = 1; g <= 9; g++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        for (int i = 1; i <= 9; i++)
                        {
                            if (num % i == 0 && 
                                num % j == 0 && 
                                num % k == 0 && 
                                num % g == 0)
                            {
                                Console.Write($"{g}{k}{j}{i} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
