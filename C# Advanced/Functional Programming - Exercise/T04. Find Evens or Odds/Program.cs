using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startNum = int.Parse(input.Split()[0]);
            int endNum = int.Parse(input.Split()[1]);

            List<int> numbers = new List<int>();
            for (int num = startNum; num <= endNum; num++)
            {
                numbers.Add(num);
            }

            Predicate<int> predicate = null;
            string type = Console.ReadLine();

            if (type == "even")
            {
                predicate = num => num % 2 == 0;
                //var evenNums = numbers.FindAll(predicate);
                //Console.WriteLine(String.Join(" ", evenNums));
            }
            else if (type == "odd")
            {
                predicate = num => num % 2 != 0;
                //var oddNums = numbers.FindAll(predicate);
                //Console.WriteLine(String.Join(" ", oddNums));
            }

            Console.WriteLine(String.Join(" ", numbers.FindAll(predicate)));
        }
    }
}
