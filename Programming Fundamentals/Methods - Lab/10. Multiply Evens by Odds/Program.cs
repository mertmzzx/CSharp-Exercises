using System;
using System.Linq;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));

            int evenDigitsSum = GetDigitsSum(input, 0);
            int oddDigitsSum = GetDigitsSum(input, 1);

            Console.WriteLine(evenDigitsSum*oddDigitsSum);
        }

       static int GetDigitsSum(int input, int evenOddCheck)
       {
           int sum = 0;
           while (input > 0)
           {
               int digit = input % 10;
               if (digit % 2 == evenOddCheck)
               {
                   sum += digit;
               }

               input /= 10;
           }

           return sum;
       }
    }
}
