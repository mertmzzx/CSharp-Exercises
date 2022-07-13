using System;

namespace BirthdayCelebrations
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> populationList = new List<IBirthable>();

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    IBirthable lifeForm = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    populationList.Add(lifeForm);
                }
                else if (tokens[0] == "Pet")
                {
                    IBirthable lifeForm = new Pet(tokens[1], tokens[2]);
                    populationList.Add(lifeForm);
                }

                cmd = Console.ReadLine();
            }

            string year = Console.ReadLine();

            List<string> sorted = populationList
                .Where(x => x.Birthdate.EndsWith(year))
                .Select(x => x.Birthdate)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, sorted));
        }
    }
}
