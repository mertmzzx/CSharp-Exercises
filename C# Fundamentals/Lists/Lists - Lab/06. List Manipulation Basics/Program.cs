using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int addNumber = int.Parse(tokens[1]);
                        numbers.Add(addNumber);
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(tokens[1]);
                        numbers.Remove(removeNumber);
                        break;
                    case "RemoveAt":
                        int removeAtNumber = int.Parse(tokens[1]);
                        numbers.RemoveAt(removeAtNumber);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(tokens[1]);
                        int insertIndex = int.Parse(tokens[2]);
                        numbers.Insert(insertIndex, insertNumber);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
