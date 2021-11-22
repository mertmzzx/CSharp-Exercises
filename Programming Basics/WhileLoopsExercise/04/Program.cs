using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;

            string input;

            while (steps < 10000)
            {
                input = Console.ReadLine();

                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    steps += int.Parse(input);
                    break;
                }

                steps += int.Parse(input);
            }

            if (10000 > steps)
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }
        }
    }
}
