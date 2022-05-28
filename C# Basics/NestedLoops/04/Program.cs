using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinationsCounter = 0;
            bool isMagicNumFound = false;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    combinationsCounter++;

                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinationsCounter} ({i} + {j} = {magicNum})");
                        isMagicNumFound = true;
                        break;
                    }
                }

                if (isMagicNumFound)
                {
                    break;
                }
            }

            if (!isMagicNumFound)
            {
                Console.WriteLine($"{combinationsCounter} combinations - neither equals {magicNum}");
            }
        }
    }
}
