using System;

namespace Problem_4___World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = (Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string destination = tokens[2];
                    if (index >= 0 && index <= text.Length - 1)
                    {
                        text = text.Insert(index, destination);
                    }

                    Console.WriteLine(text);
                }
                else if (tokens[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && startIndex <= text.Length - 1 && endIndex >= 0 && endIndex <= text.Length - 1)
                    {
                        text = text.Remove(startIndex, endIndex+1 - startIndex);
                    }

                    Console.WriteLine(text);
                }
                else if (tokens[0] == "Switch")
                {
                    string firstCountry = tokens[1];
                    string secondCountry = tokens[2];
                    if (text.Contains(firstCountry))
                    {
                        text = text.Replace(firstCountry, secondCountry);
                    }

                    Console.WriteLine(text);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
