using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            while (n > 0)
            {
                char input = char.Parse(Console.ReadLine());
                int i = Convert.ToChar(input);

                sum += i;
                n--;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
