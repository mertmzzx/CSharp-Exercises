using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            while (num > 0 && text != "STOP")
            {
                Console.WriteLine("Hello");

                num = int.Parse(Console.ReadLine());
                text = Console.ReadLine();
            }
        }
    }
}
