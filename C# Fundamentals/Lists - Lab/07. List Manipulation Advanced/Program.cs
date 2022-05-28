using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool change = false;

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split();
                if (tokens[0] == "Add")
                {
                    int addNumber = int.Parse(tokens[1]);
                    numbers.Add(addNumber);
                    change = true;
                }
                else if (tokens[0] == "Remove")
                {
                    int removeNumber = int.Parse(tokens[1]);
                    numbers.Remove(removeNumber);
                    change = true;
                }
                else if (tokens[0] == "RemoveAt")
                {
                    int removeAtNumber = int.Parse(tokens[1]);
                    numbers.RemoveAt(removeAtNumber);
                    change = true;
                }
                else if (tokens[0] == "Insert")
                {
                    int insertNumber = int.Parse(tokens[1]);
                    int insertIndex = int.Parse(tokens[2]);
                    numbers.Insert(insertIndex, insertNumber);
                    change = true;
                }
                else if (tokens[0] == "Contains")
                {
                    Contains(tokens, numbers);
                }
                else if (tokens[0] == "PrintEven")
                {
                    PrintEven(tokens,numbers);
                }
                else if (tokens[0] == "PrintOdd")
                {
                    PrintOdd(tokens, numbers);
                }
                else if (tokens[0] == "GetSum")
                {
                    GetSum(tokens, numbers);
                }
                else if (tokens[0] == "Filter")
                {
                    Filter(tokens, numbers);
                }

                line = Console.ReadLine();
            }

            if (change == true)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void Contains(string[] tokens, List<int> numbers)
        {
            int numberContains = int.Parse(tokens[1]);

            if (numbers.Contains(numberContains))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEven(string[] tokens, List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }

            Console.WriteLine();
        }

        static void PrintOdd(string[] tokens, List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }

            Console.WriteLine();
        }

        static void GetSum(string[] tokens, List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }

        static void Filter(string[] tokens, List<int> numbers)
        {
            switch (tokens[1])
            {
                case "<":
                    int number = int.Parse(tokens[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < number)
                        {
                            Console.Write($"{numbers[i]} ");
                        }
                    }
                    break;
                case ">":
                    int number2 = int.Parse(tokens[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] > number2)
                        {
                            Console.Write($"{numbers[i]} ");
                        }
                    }
                    break;
                case ">=":
                    int number3 = int.Parse(tokens[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] >= number3)
                        {
                            Console.Write($"{numbers[i]} ");
                        }
                    }
                    break;
                case "<=":
                    int number4 = int.Parse(tokens[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= number4)
                        {
                            Console.Write($"{numbers[i]} ");
                        }
                    }
                    break;
            }

            Console.WriteLine();
        }
    }
}
