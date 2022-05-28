using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double result = 0;

            if (operation == "+")
            {
                result = N1 + N2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} + {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} + {N2} = {result} - odd");
                }
            }
            else if (operation == "-")
            {
                result = N1 - N2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} - {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} - {N2} = {result} - odd");
                }
            }
            else if (operation == "*")
            {

                result = N1 * N2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} * {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} * {N2} = {result} - odd");
                }
            }
            else if (operation == "/")
            {
                result = N1 / N2;

                if (N2 != 0)
                {
                    Console.WriteLine($"{N1} / {N2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
            else if (operation == "%")
            {
                result = N1 % N2;

                if (N2 != 0)
                {
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
        }
    }
}
