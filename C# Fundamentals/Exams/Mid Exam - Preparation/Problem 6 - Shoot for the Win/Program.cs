using System;
using System.Linq;

namespace Problem_6___Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int shotsCount = 0;

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);

                if (index >= targets.Length)
                {
                    continue;
                }
                else if (targets[index] == -1)
                {
                    continue;
                }

                int currValue = targets[index];

                targets[index] = -1;
                shotsCount++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] != -1)
                    {
                        if (currValue < targets[i])
                        {
                            targets[i] -= currValue;
                        }
                        else if (currValue >= targets[i])
                        {
                            targets[i] += currValue;
                        }
                    }
                }
            }

            Console.Write($"Shot targets: {shotsCount} -> ");
            foreach (var item in targets)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
