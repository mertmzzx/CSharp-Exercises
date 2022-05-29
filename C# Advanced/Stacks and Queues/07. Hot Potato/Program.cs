using System;
using System.Collections;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(players);

            while (queue.Count > 1)
            {
                for (int i = 1; i <= n-1; i++)
                {
                    var player = queue.Dequeue();
                    queue.Enqueue(player);
                }

                var lostPlayer = queue.Dequeue();
                Console.WriteLine($"Removed {lostPlayer}");
            }

            var lastPlayer = queue.Dequeue();
            Console.WriteLine($"Last is {lastPlayer}");
        }
    }
}
