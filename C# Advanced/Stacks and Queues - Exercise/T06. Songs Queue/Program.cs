using System;
using System.Collections.Generic;

namespace T06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsQueue = new Queue<string>(Console.ReadLine().Split(", "));

            while (songsQueue.Count > 0)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (cmd.Contains("Add"))
                {
                    string song = cmd.Substring(4);

                    if (songsQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(song);
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
