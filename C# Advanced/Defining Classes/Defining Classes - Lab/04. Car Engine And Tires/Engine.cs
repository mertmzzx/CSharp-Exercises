using System;

namespace CarManufacturer
{
    public class Engine
    {
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, int cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public static void Run()
        {
            Console.WriteLine("I am an engine. I am running.");
        }
    }
}