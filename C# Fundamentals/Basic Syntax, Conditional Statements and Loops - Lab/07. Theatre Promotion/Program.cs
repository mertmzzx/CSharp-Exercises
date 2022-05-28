using System;

namespace _7._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (18 >= age && age >= 0)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("12$");
                }
                else if (day == "Weekend")
                {
                    Console.WriteLine("15$");
                }
                else
                {
                    Console.WriteLine("5$");
                }
            }
            else if (64 >= age && age > 18)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("18$");
                }
                else if (day == "Weekend")
                {
                    Console.WriteLine("20$");
                }
                else
                {
                    Console.WriteLine("12$");
                }
            }
            else if (age > 64 && age <= 122)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("12$");
                }
                else if (day == "Weekend")
                {
                    Console.WriteLine("15$");
                }
                else
                {
                    Console.WriteLine("10$");
                }
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
