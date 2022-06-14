using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int indexSlash = input.LastIndexOf(@"\");
            int indexPoint = input.IndexOf('.');
            string fileName = input.Substring(indexSlash + 1, indexPoint - indexSlash - 1);

            string extention = input.Substring(indexPoint + 1, input.Length - indexPoint - 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}
