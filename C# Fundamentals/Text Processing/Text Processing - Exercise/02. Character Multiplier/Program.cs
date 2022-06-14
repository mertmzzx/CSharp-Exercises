using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string word1 = input[0];
            string word2 = input[1];

            string shortWord = string.Empty;
            string longWord = string.Empty;
            int shorterWordLength = Math.Min(word1.Length, word2.Length);

            if (shorterWordLength == word1.Length)
            {
                shortWord = word1;
                longWord = word2;
            }
            else
            {
                shortWord = word2;
                longWord = word1;
            }

            char[] longArray = longWord.ToCharArray();
            char[] shortArray = shortWord.ToCharArray();

            int startIndex = shortWord.Length;
            int endIndex = longWord.Length - shortWord.Length;
            string remaining = longWord.Substring(startIndex, endIndex);
            char[] remainingChars = remaining.ToCharArray();
            int sum = 0;

            for (int i = 0; i < shortWord.Length; i++)
            {
                sum += longArray[i] * shortArray[i];
            }

            foreach (var charToAdd in remainingChars)
            {
                sum += charToAdd;
            }

            Console.WriteLine(sum);
        }
    }
}
