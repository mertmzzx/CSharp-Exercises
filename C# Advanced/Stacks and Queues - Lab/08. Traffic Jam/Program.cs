using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int carsPassed = 0;
            int n = int.Parse(Console.ReadLine());

            string cmd = Console.ReadLine();

            while (cmd != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        // Green light --> pass n cars ahead
                        if (queue.Count > 0)
                        {
                            var car = queue.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            carsPassed++;
                        }
                    }   
                }
                else
                {
                    queue.Enqueue(cmd);
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
