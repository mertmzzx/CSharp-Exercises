using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int min = int.MaxValue;

            while (n != "Stop")
            {
                int input = int.Parse(n);

                if (input < min)
                {
                    min = input;
                }

                n = Console.ReadLine();
            }

            Console.WriteLine(min);
        }
    }
}
