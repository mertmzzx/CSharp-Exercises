using System;
using AnimalFarm.Models;

namespace AnimalFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken;

            try
            {
                 chicken = new Chicken(name, age);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            Console.WriteLine(chicken);
        }
    }
}
