using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestsList = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string guest = Console.ReadLine();

                string[] token = guest.Split();
                if (token[2] == "going!")
                {
                    if (!guestsList.Contains(token[0]))
                    {
                        guestsList.Add(token[0]);
                    }
                    else if (guestsList.Contains(token[0]))
                    {
                        Console.WriteLine($"{token[0]} is already in the list!");
                    }
                }
                else if (token[2] == "not")
                {
                    if (!guestsList.Contains(token[0]))
                    {
                        Console.WriteLine($"{token[0]} is not in the list!");
                    }
                    else if (guestsList.Contains(token[0]))
                    {
                        guestsList.Remove(token[0]);
                    }
                }
            }

            foreach (var guest in guestsList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
