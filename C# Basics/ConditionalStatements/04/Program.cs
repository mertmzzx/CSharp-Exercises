using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string convertedType = Console.ReadLine();

            if (type == "mm" && convertedType == "cm")
            {
                number = number * 0.1;
                Console.WriteLine($"{number:F3}");
            }
            else if (type == "cm" && convertedType == "m")
            {
                number = number * 0.01;
                Console.WriteLine($"{number:F3}");
            }
            else if (type == "mm" && convertedType == "m")
            {
                number = number * 0.001;
                Console.WriteLine($"{number:F3}");
            }
            else if (type == "m" && convertedType == "cm")
            {
                number = number * 100;
                Console.WriteLine($"{number:F3}");
            }
            else if (type == "cm" && convertedType == "mm")
            {
                number = number * 10;
                Console.WriteLine($"{number:F3}");
            }
            else if (type == "m" && convertedType == "mm")
            {
                number = number * 1000;
                Console.WriteLine($"{number:F3}");
            }
        }
    }
}