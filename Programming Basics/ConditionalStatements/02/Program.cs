using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double bonus = 0;

            if (n < 100)
            {
                bonus = 5;
            }
            else if (n > 1000)
            {
                bonus = n * 10 / 100;
            }
            else
            {
                bonus = n * 20 / 100;
            }

            if (n % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (n % 10 == 5)
            {
                bonus += 2; // bonus += 2 е едно и също с bonus = bonus + 2
            }

            Console.WriteLine(bonus);
            Console.WriteLine(n+bonus);
        }
    }
}
