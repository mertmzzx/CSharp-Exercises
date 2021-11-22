using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            char Operator = char.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            if (Operator == '+')
            {
                double result = Add(num1, num2);

                Console.WriteLine(result);
            }
            else if (Operator == '-')
            {
                double result = Substract(num1, num2);

                Console.WriteLine(result);
            }
            else if (Operator == '*')
            {
                double result = Multiply(num1, num2);

                Console.WriteLine(result);
            }
            else
            {
                double result = Divide(num1, num2);

                Console.WriteLine(result);
            }
        }

        static double Substract(double num1, double num2)
        {
            double result = num1 - num2;

            return result;
        }

        static double Add(double num1, double num2)
        {
            double result = num1 + num2;

            return result;
        }

        static double Multiply(double num1, double num2)
        {
            double result = num1 * num2;

            return result;
        }

        static double Divide(double num1, double num2)
        {
            double result = num1 / num2;

            return result;
        }
    }
}
