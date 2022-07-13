
namespace BorderControl
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> populationList = new List<IIdentifiable>();

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    IIdentifiable person = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    populationList.Add(person);
                }
                else
                {
                    IIdentifiable robot = new Robot(tokens[0], tokens[1]);
                    populationList.Add(robot);
                }

                cmd = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();
            
            foreach (IIdentifiable lifeForm in populationList)
            {
                if (lifeForm.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(lifeForm.Id);
                }
            }
        }
    }
}
