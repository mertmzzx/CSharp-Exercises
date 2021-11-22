using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;
            double p4 = 0.00;
            double p5 = 0.00;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1++;
                }
                else if (200 <= num && num <= 399)
                {
                    p2++;
                }
                else if (400 <= num && num <= 599)
                {
                    p3++;
                }
                else if (600 <= num && num <= 799)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            p1 = (p1 / n) * 100;
            p2 = (p2 / n) * 100;
            p3 = (p3 / n) * 100;
            p4 = (p4 / n) * 100;
            p5 = (p5 / n) * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
