using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double oddMin = int.MaxValue;
            double evenMin = int.MaxValue;
            double oddMax = int.MinValue;
            double evenMax = int.MinValue;
            double evenSum = 0.0;
            double oddSum = 0.0;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;

                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;

                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");


            if (oddMin == int.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
            }
            if (oddMax == int.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:F2},");
            }

            Console.WriteLine($"EvenSum={evenSum:F2},");

            Console.WriteLine(evenMin == int.MaxValue ? "EvenMin=No," : $"EvenMin={evenMin:F2},");
            Console.WriteLine(evenMax == int.MinValue ? "EvenMax=No" : $"EvenMax={evenMax:F2}");

            //if (evenMin == int.MaxValue)
            //{
            //    Console.WriteLine("EvenMin=No,");
            //}
            //else
            //{
            //    Console.WriteLine($"EvenMin={evenMin:F2},");
            //}
            //if (evenMax == double.MinValue)
            //{
            //    Console.WriteLine("EvenMax=No");
            //}
            //else
            //{
            //    Console.WriteLine($"EvenMax={evenMax:F2}");
            //}
        }
    }
}
