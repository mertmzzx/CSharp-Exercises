namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt"; // файл за четене
            string outputFilePath = @"..\..\..\output.txt"; //файл за писане

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> outputLines = new List<string>();

            foreach (string line in lines)
            {
                count++;
                //2. броим буквите
                int countLetters = line.Count(char.IsLetter); //37
                //3. броим символите, които са пунктуационни знаци
                int countSymbol = line.Count(char.IsPunctuation); //4
                //1. номер на реда
                string modifiedLine = $"Line {count}: {line} ({countLetters})({countSymbol})";

                outputLines.Add(modifiedLine);
            }

            File.WriteAllLines(outputFilePath, outputLines);
        }
    }
}