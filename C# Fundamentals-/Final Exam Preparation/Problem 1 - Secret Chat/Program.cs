using System;
using System.Linq;

namespace Problem_1___Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] cmdTokens = command.Split(":|:");
                if (cmdTokens[0] == "ChangeAll")
                {
                    string substring = cmdTokens[1];
                    string replacement = cmdTokens[2];
                    message = message.Replace(substring, replacement);
                }
                else if (cmdTokens[0] == "InsertSpace")
                {
                    int index = int.Parse(cmdTokens[1]);
                    message = message.Insert(index, " ");
                }
                else if (cmdTokens[0] == "Reverse")
                {
                    string substring = cmdTokens[1];
                    if (message.Contains(substring))
                    {
                        int index = message.IndexOf(substring);
                        message = message.Remove(index, substring.Length);
                        message = message + string.Join("", substring.Reverse());
                    }
                    else
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                }

                Console.WriteLine(message);
                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
