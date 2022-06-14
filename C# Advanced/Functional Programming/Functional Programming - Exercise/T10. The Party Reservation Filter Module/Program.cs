using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partyPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string cmd = command.Split(";")[0];
                string condition = command.Split(";")[1];
                string argument = command.Split(";")[2];
                switch (cmd)
                {
                    case "Add filter":
                        Predicate<string> currentPredicate = GetPredicate(condition, argument);
                        filters.Add(argument, currentPredicate);
                        break;
                    case "Remove filter":
                        currentPredicate = GetPredicate(condition, argument);
                        filters.Remove(argument);
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                partyPeople.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", partyPeople));
        }

        private static Predicate<string> GetPredicate(string filter, string parameter)
        {
            switch (filter)
            {
                case "Starts with":
                    return (name) => name.StartsWith(parameter);
                case "Ends with":
                    return (name) => name.EndsWith(parameter);
                case "Length":
                    return (name) => name.Length == int.Parse(parameter);
                case "Contains":
                    return (name) => name.Contains(parameter);
                default:
                    throw new ArgumentException("Invalid command type: " + filter);
            }
        }
    }
}
