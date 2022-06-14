using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ores = new Dictionary<string, int>();
            string resources = Console.ReadLine();

            while (resources != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!ores.ContainsKey(resources))
                {
                    ores[resources] = 0;
                    //ores.Add(resources, 0)
                }

                ores[resources] += quantity;
                resources = Console.ReadLine();
            }

            foreach (var ore in ores)
            {
                Console.WriteLine($"{ore.Key} -> {ore.Value}");
            }
        }
    }
}
