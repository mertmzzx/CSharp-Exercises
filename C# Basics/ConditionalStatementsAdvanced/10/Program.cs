using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool isValid = (num >= 100 && num <= 200) || (num == 0);

            if (!isValid)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
