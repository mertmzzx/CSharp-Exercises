using System;
using System.Linq;
using System.Security.Principal;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string sequence = "";
            int counter = 0;
            int longestCounter = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    counter++;

                    if (counter > longestCounter)
                    {
                        longestCounter = counter;
                        sequence = input[i].ToString();
                    }
                }
                else
                {
                    counter = 0;
                }
            }

            for (int i = 0; i <= longestCounter; i++)
            {
                Console.Write($"{sequence} ");
            }
        }
    }
}
