using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int result = Substract(n1, n2, n3);

            Console.WriteLine(result);
        }

        static int Sum(int n1, int n2)
        {
            int sum = n1 + n2;

            return sum;
        }

        static int Substract(int n1, int n2, int n3)
        {
            int substract = Sum(n1,n2) - n3;

            return substract;
        }
    }
}
