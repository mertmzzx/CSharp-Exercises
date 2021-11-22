using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random random = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                int swapPosition = random.Next(words.Length);
                string temp = words[i];
                words[i] = words[swapPosition];
                words[swapPosition] = temp;
            }

            Console.WriteLine(String.Join("\n", words));
        }
    }
}
