using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double S = 0.00;

            if (figure == "square")
            {
                double length = double.Parse(Console.ReadLine());

                S = length * length;
            }
            else if (figure == "rectangle")
            {
                double lenghtA = double.Parse(Console.ReadLine());
                double widht = double.Parse(Console.ReadLine());

                S = lenghtA * widht;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());

                S = Math.PI * (radius * radius);
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                S = (a * h) / 2;
            }

            Console.WriteLine($"{S:F3}");
        }
    }
}
