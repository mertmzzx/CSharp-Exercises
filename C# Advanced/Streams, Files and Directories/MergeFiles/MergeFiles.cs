using System.Linq;

namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var list = File.ReadAllLines(firstInputFilePath).ToList();
            list.AddRange(File.ReadAllLines(secondInputFilePath));
            list.Sort();
            File.WriteAllLines(outputFilePath, list);
        }
    }
}
