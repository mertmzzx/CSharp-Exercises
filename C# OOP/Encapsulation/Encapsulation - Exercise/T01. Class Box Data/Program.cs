using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box;

            try
            {
                box = new Box(lenght, width, height);

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            Console.WriteLine(box);
        }
    }
}
