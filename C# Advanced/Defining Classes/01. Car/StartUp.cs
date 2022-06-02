using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();
            car.Make = "BMW";
            car.Model = "X6";
            car.Year = 2022;

            //Car car = new Car()
            //{
            //    Make = "Toyota",
            //    Model = "Avensis",
            //    Year = 2018
            //};

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}