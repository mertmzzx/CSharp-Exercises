using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] carbon = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> qSteel = new Queue<int>(steel);
            Stack<int> stackCarbon = new Stack<int>(carbon);

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>()
            {
                {"Gladius", 0},
                {"Shamshir", 0},
                {"Katana", 0},
                {"Sabre", 0},
                {"Broadsword", 0}
            };

            int totalSwords = 0;

            while (qSteel.Count > 0 && stackCarbon.Count > 0)
            {
                int currSteel = qSteel.Peek();
                int currCarbon = stackCarbon.Peek();
                int sum = currSteel + currCarbon;

                if (sum == 70)
                {
                    swords["Gladius"]++;
                    totalSwords++;
                    qSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    totalSwords++;
                    qSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                    totalSwords++;
                    qSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    totalSwords++;
                    qSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                    totalSwords++;
                    qSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else
                {
                    qSteel.Dequeue();
                    currCarbon += 5;
                    stackCarbon.Pop();
                    stackCarbon.Push(currCarbon);
                }
            }

            if (totalSwords > 0)
            {
                Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (qSteel.Count > 0)
            {
                Console.WriteLine("Steel left: " + string.Join(", ", qSteel));
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (stackCarbon.Count > 0)
            {
                Console.WriteLine("Carbon left: " + string.Join(", ", stackCarbon));
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swords)
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
