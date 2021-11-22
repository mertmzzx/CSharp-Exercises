using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int freeSpace = 0;
            string ticket = "";

            int currentMovieTickets = 0;
            int totalTickets = 0;
            int studentCounter = 0;
            int standardCounter = 0;
            int kidCounter = 0;

            while (movie != "Finish")
            {
                freeSpace = int.Parse(Console.ReadLine());

                for (int i = 0; i < freeSpace; i++)
                {
                    ticket = Console.ReadLine();

                    if (ticket == "End")
                    {
                        break;
                    }

                    currentMovieTickets++;

                    switch (ticket)
                    {
                        case "student":
                            studentCounter++;
                            break;
                        case "standard":
                            standardCounter++;
                            break;
                        case "kid":
                            kidCounter++;
                            break;
                    }
                }

                Console.WriteLine($"{movie} - {(double)(currentMovieTickets / (double)freeSpace) * 100.0:F2}% full.");

                currentMovieTickets = 0;

                movie = Console.ReadLine();
            }
            
            totalTickets += standardCounter + studentCounter + kidCounter;


            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{((double)studentCounter / (double)totalTickets)*100:F2}% student tickets.");
            Console.WriteLine($"{((double)standardCounter / (double)totalTickets)*100:F2}% standard tickets.");
            Console.WriteLine($"{((double)kidCounter / (double)totalTickets)*100:F2}% kids tickets.");
        }
    }
}
