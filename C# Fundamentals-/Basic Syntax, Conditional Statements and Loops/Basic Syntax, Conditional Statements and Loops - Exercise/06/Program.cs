using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int temNumber = num;
            int factorialSum = 0;

            while (temNumber > 0)
            {
                int currNumber = temNumber % 10;
                temNumber /= 10;
                int currFactNum = 1;

                for (int i = 1; i <= currNumber; i++)
                {
                    currFactNum *= i;
                }

                factorialSum += currFactNum;
            }

            string result = factorialSum == num ? "yes" : "no";
            Console.WriteLine(result);
        }
    }
}
