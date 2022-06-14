using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string[] action = Console.ReadLine().Split();

            while (action[0] != "Retire")
            {
                if (action[0] == "Fire")
                {
                    int index = int.Parse(action[1]);
                    int damage = int.Parse(action[2]);

                    if (index >= 0 && index < warShip.Count)
                    {
                        warShip[index] -= damage;

                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine($"You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (action[0] == "Defend")
                {
                    int firstIndex = int.Parse(action[1]);
                    int lastIndex = int.Parse(action[2]);
                    int damage = int.Parse(action[3]);

                    if (firstIndex >= 0 && firstIndex < pirateShip.Count && lastIndex >= 0 && lastIndex < pirateShip.Count)
                    {
                        for (int sections = firstIndex; sections <= lastIndex; sections++)
                        {
                            pirateShip[sections] -= damage;

                            if (pirateShip[sections] <= 0)
                            {
                                Console.WriteLine($"You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (action[0] == "Repair")
                {
                    int index = int.Parse(action[1]);
                    int health = int.Parse(action[2]);

                    if (index >= 0 && index < pirateShip.Count)
                    {
                        if (pirateShip[index] + health >= maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }
                        else
                        {
                            pirateShip[index] += health;
                        }
                    }
                }
                else
                {
                    int sections = pirateShip.Count(number => number / (double) maxHealth * 100 < 20);
                    Console.WriteLine($"{sections} sections need repair.");
                }

                action = Console.ReadLine().Split();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}