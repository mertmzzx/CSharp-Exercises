using System;
using System.Text;

namespace Problem_1___Hogwarts
{
    class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            StringBuilder sb = new StringBuilder(spell);
            string command = Console.ReadLine();
            while (command != "Abracadabra")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Abjuration")
                {
                    spell = sb.ToString().ToUpper();
                    Console.WriteLine(spell);
                    sb.Clear();
                    sb.Append(spell);
                }
                else if (tokens[0] == "Necromancy")
                {

                    spell = sb.ToString().ToLower();
                    Console.WriteLine(spell);
                    sb.Clear();
                    sb.Append(spell);
                }
                else if (tokens[0] == "Illusion")
                {
                    int startIndex = int.Parse(tokens[1]);
                    string letterForRemove = tokens[2];
                    if (startIndex >= 0 && startIndex < sb.Length)
                    {
                        sb = sb.Remove(startIndex, 1);
                        sb = sb.Insert(startIndex, letterForRemove);
                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                }
                else if (tokens[0] == "Divination")
                {
                    string oldSubstring = tokens[1];
                    string newSubstring = tokens[2];
                    if (sb.ToString().Contains(oldSubstring))
                    {
                        spell = sb.ToString().Replace(oldSubstring, newSubstring);
                        Console.WriteLine(spell);
                        sb.Clear();
                        sb.Append(spell);
                    }
                }
                else if (tokens[0] == "Alteration")
                {
                    string substring = tokens[1];
                    if (sb.ToString().Contains(substring))
                    {
                        int index = sb.ToString().IndexOf(substring);
                        spell = sb.ToString().Remove(index, substring.Length);
                        sb.Clear();
                        sb.Append(spell);

                    }

                    Console.WriteLine(spell);
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
                command = Console.ReadLine();
                ;
            }
        }
    }
}
