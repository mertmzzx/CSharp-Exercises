using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (string item in input)
            {
                char firstLetter = item[0];
                char lastLetter = item[^1];
                string numAsAString = item[1..^1];
                double numFormString = double.Parse(numAsAString);

                if (char.IsUpper(firstLetter))
                {
                    int positionOfTheLetter = firstLetter - 64;
                    numFormString /= positionOfTheLetter;
                }
                else
                {
                    int positionOfTheLetter = firstLetter - 96;
                    numFormString *= positionOfTheLetter;
                }

                if (char.IsUpper(lastLetter))
                {
                    int positionOfTheLetter = lastLetter - 64;
                    numFormString -= positionOfTheLetter;
                }
                else
                {
                    int positionOfTheLetter = lastLetter - 96;
                    numFormString += positionOfTheLetter;
                }
                sum += numFormString;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
