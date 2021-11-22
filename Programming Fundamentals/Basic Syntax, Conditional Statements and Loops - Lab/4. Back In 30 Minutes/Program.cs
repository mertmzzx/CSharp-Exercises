using System;

namespace _4._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine()) + 30;

            if (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }

            if (hours > 23)
            {
                hours -= 24;
            }

            if (minutes<10)
            {
                Console.WriteLine(hours + ":" + minutes.ToString("00"));
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
