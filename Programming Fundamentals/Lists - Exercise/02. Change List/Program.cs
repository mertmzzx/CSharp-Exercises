using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] token = command.Split();
                if (token[0] == "Delete")
                {
                    int number = int.Parse(token[1]);

                    numbers.RemoveAll(el => el == number);
                }
                else
                {
                    int number = int.Parse(token[1]);
                    int index = int.Parse(token[2]);

                    numbers.Insert(index, number);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
