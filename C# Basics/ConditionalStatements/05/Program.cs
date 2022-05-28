using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            string zero = "";

            minutes = minutes + 15;
            if (minutes > 59)
            {
                hours = hours + 1;
                minutes = minutes - 60;
            }
            if (minutes < 10)
            {
                zero = "0";
            }

            Console.WriteLine("{0}:{1}{2}", hours % 24, zero, minutes % 60);
        }
    }
}
