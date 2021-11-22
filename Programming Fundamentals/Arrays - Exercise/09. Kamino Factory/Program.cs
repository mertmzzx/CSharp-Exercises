using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] dna = new int[n];
            int dnaSum = 0;
            int dnaCounter = -1;
            int dnaStartIndex = -1;
            int dnaSamples = 0;

            int sample = 0;
            while (input != "Clone them!")
            {
                // CURRENT DNA INFO
                sample++;

                int[] currDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDnaSum = 0;
                bool isCurrDnaBetter = false;

                int count = 0;
                for (int i = 0; i < currDna.Length; i++)
                {
                    if (currDna[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }
                //01101
                // 0 11 0 1 => 11 (endIndex = 2) => (startIndex = 2 - 2 = 0 + 1 => 1
                currStartIndex = currEndIndex - currCount + 1;
                // 01101.Sum() => 3
                currDnaSum = currDna.Sum();

                //CHECK CURRENT DNA WITH BEST DNA
                if (currCount > dnaCounter)
                {
                    isCurrDnaBetter = true;
                }
                else if (currCount == dnaCounter)
                {
                    if (currStartIndex < dnaStartIndex)
                    {
                        isCurrDnaBetter = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        if (currDnaSum > dnaSum)
                        {
                            isCurrDnaBetter = true;
                        }
                    }
                }

                if (isCurrDnaBetter)
                {
                    dna = currDna;
                    dnaCounter = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", dna));
        }
    }
}
