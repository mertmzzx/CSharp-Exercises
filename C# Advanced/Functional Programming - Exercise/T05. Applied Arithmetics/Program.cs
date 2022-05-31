using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));
            Func<List<int>, List<int>> operation = null;

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        operation = list => list.Select(number => number += 1).ToList();
                        numbers = operation(numbers);
                        break;
                    case "multiply":
                        operation = list => list.Select(number => number *= 2).ToList();
                        numbers = operation(numbers);
                        break;
                    case "subtract":
                        operation = list => list.Select(number => number -= 1).ToList();
                        numbers = operation(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
