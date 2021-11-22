using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                    if (time>=10 && time<=18)
                    {
                        Console.WriteLine("open");
                    }
                    else
                    {
                        Console.WriteLine("closed");
                    }

                    break;
                default:
                    Console.WriteLine("closed");
                    break;
            }
        }
    }
}
