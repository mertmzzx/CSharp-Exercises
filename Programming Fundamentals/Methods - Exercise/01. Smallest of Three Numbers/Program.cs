using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int num = SmallestNumber(a,b,c);

            Console.WriteLine(num);
        }

        static int SmallestNumber(int a, int b, int c)
        {
            int smallestNum = 0;

            if (a <= b && a <= c)
            {
                smallestNum = a;
            }
            else if (b <= a && b <= c)
            {
                smallestNum = b;
            }
            else if (c <= a && c <= b)
            {
                smallestNum = c;
            }

            return smallestNum;
        }
    }
}
