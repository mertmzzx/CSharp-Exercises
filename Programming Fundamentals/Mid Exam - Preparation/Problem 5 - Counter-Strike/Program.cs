using System;

namespace Problem_5___Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int battlesWon = 0;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    return;
                }

                energy -= distance;
                battlesWon++;
                if (battlesWon % 3 == 0) energy += battlesWon;

                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
        }
    }
}
