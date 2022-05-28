using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstMax = int.Parse(Console.ReadLine());
            int secondMax = int.Parse(Console.ReadLine());
            int thirdMax = int.Parse(Console.ReadLine());

            for (int i = 2; i <= firstMax; i+=2)
            {
                for (int k = 2; k <= secondMax; k++)
                {
                    for (int j = 2; j <= thirdMax; j += 2)
                    {
                        if (k == 2 || k == 3 || k == 5 || k == 7)
                        {
                            Console.WriteLine($"{i} {k} {j}");
                        }
                    }
                }
            }
        }
    }
}
