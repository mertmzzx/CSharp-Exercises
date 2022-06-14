using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] token = command.Split();

                if (token[0] == "Add")
                {
                    int number = int.Parse(token[1]);
                    numbers.Add(number);
                }
                else if (token[0] == "Insert")
                {
                    int number = int.Parse(token[1]);
                    int index = int.Parse(token[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }
                }
                else if (token[0] == "Remove")
                {
                    int index = int.Parse(token[1]);

                    if (index >= 0 || index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }
                }
                else if (token[1] == "left")
                {
                    ShiftLeft(token, numbers);
                }
                else if (token[1] == "right")
                {
                    ShiftRight(token, numbers);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void ShiftRight(string[] token, List<int> numbers)
        {
            int count = int.Parse(token[2]);

            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
        }

        private static void ShiftLeft(string[] token, List<int> numbers)
        {
            int count = int.Parse(token[2]);

            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
        }
    }
}
