using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string encryptedString = string.Empty;
            foreach (char currChar in input)
            {
                int currPostion = currChar;
                currPostion += 3; 
                encryptedString += (char)currPostion;
            }
            Console.WriteLine(encryptedString);
        }
    }
}
