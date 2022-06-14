namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            //1. създаваме output директорията
            Directory.CreateDirectory(outputPath);
            //2. взимам всички файлове от input directory
            string[] files = Directory.GetFiles(inputPath);
            //3. всеки файл го копирам в output directory
            foreach (string file in files)
            {
                var fileName = Path.GetFileName(file); //взимаме файла с име 
                var copyDestination = Path.Combine(outputPath, fileName);
                File.Copy(fileName, copyDestination);
            }
        }
    }
}