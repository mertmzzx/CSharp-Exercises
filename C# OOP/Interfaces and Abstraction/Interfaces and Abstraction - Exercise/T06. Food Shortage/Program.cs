namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length == 4)
                {
                    IBuyer citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rebel);
                }
            }

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                buyers.ForEach(x => x.BuyFood(cmd));

                cmd = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
