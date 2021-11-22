using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7___Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] token = command.Split();

                if (token[0] == "Shoot")
                {
                    ShootTarget(targets, token);
                }
                else if (token[0] == "Add")
                {
                    AddTarget(targets, token);
                }
                else if (token[0] == "Strike")
                {
                    StrikeTarget(targets, token);
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }

        private static void StrikeTarget(List<int> targets, string[] token)
        {
            int index = int.Parse(token[1]);
            int radius = int.Parse(token[2]);

            if (index - radius >= 0 && index + radius < targets[targets.Count - 1])
            {
                targets.RemoveRange(index - radius, radius * 2 + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }

        private static void AddTarget(List<int> targets, string[] token)
        {
            int index = int.Parse(token[1]);
            int value = int.Parse(token[2]);

            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        private static void ShootTarget(List<int> targets, string[] token)
        {
            int index = int.Parse(token[1]);
            int power = int.Parse(token[2]);
            if (index >= 0 && index < targets.Count)
            {
                targets[index] -= power;

                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
        }
    }
}
