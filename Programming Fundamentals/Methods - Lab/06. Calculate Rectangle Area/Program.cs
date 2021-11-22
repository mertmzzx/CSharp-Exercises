using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double heigth =double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double area = Area(heigth, width);

            Console.WriteLine(area);
        }                  

        static double Area(double heigth, double width)
        {
            return heigth * width;
        }
    }
}
