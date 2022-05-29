using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int paidCustomers = 0;
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                if (cmd == "Paid")
                {
                    int count = queue.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (count > 0)
                        {
                            string customer = queue.Dequeue();
                            Console.WriteLine(customer);
                            paidCustomers++;
                        }
                    }
                }
                else if (!queue.Contains(cmd)) queue.Enqueue(cmd);

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
