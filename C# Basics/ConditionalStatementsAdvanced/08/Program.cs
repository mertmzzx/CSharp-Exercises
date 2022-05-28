using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int ticketPrice = 0;

            if (day == "Monday" || day == "Tuesday" || day == "Friday")
            {
                ticketPrice = 12;
            }
            else if (day == "Wednesday" || day == "Thursday")
            {
                ticketPrice = 14;
            }
            else if (day == "Sunday" || day == "Saturday")
            {
                ticketPrice = 16;
            }

            Console.WriteLine(ticketPrice);

           // 2-ри начин на решение
           // switch (day)
           // {
           //     case "Monday":
           //     case "Tuesday":
           //     case "Friday":
           //         Console.WriteLine(12);
           //         break;
           //     case "Wednesday":
           //     case "Thursday":
           //         Console.WriteLine(14);
           //         break;
           //     case "Saturday":
           //     case "Sunday":
           //         Console.WriteLine(16);
           //         break;
           // }
        }
    }
}
