using System.Linq;

namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long size = Directory.GetFiles(@"..\..\TestFolder")
                .Sum(file => new FileInfo(file).Length);
            File.WriteAllText(@"..\..\Output.txt", ((double)size / 1048576).ToString());
        }
    }
}
