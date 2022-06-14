using System;
using System.Globalization;
using System.Linq;

namespace Problem_2___Mu_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|').ToArray();
            int health = 100;
            double bitcoin = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] command = rooms[i].Split();
                if (command[0] == "potion")
                {
                    int pastHealth = health;
                    int healedPoints = int.Parse(command[1]);
                    health += healedPoints;

                    if (health > 100) health = 100;
                    int gainedHealth = health - pastHealth;
                    if (pastHealth == 100) gainedHealth = 0;

                    Console.WriteLine($"You healed for {gainedHealth} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command[0] == "chest")
                {
                    int foundedBitcoins = int.Parse(command[1]);
                    bitcoin += foundedBitcoins;

                    Console.WriteLine($"You found {foundedBitcoins} bitcoins.");
                }
                else
                {
                    string currMonster = command[0];
                    int monsterPower = int.Parse(command[1]);

                    health -= monsterPower;
                    if (health > 0) Console.WriteLine($"You slayed {currMonster}.");
                    else
                    {
                        Console.WriteLine($"You died! Killed by {currMonster}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }

            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoin}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
