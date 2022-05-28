using System.Text;

namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            //разширение -> списък с файловете
            Dictionary<string, List<FileInfo>> extensionsInfo = new Dictionary<string, List<FileInfo>>();
            //за всеки файл ни трябва разширението
            foreach (string file in files)
            {
                //информация за файла -> разришението
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!extensionsInfo.ContainsKey(extension))
                {
                    extensionsInfo.Add(extension, new List<FileInfo>());
                }

                extensionsInfo[extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var entry in extensionsInfo.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key))
            {
                //вземем на всяко разширение списъка с файловете
                string extension = entry.Key;
                sb.AppendLine(extension);
                List<FileInfo> filesInfo = entry.Value;
                //списък с файловете трябва да се сортира спрямо размета на файла
                filesInfo.OrderByDescending(file => file.Length);

                foreach (FileInfo fileInfo in filesInfo)
                {
                    //BYTES / 1024 -> KB
                    sb.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            //textContent да го напиша във файл с име reportFileName
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            //"C:\Users\I353529\Desktop" + "\report.txt" -> "C:\Users\I353529\Desktop\report.txt"
            File.WriteAllText(pathReport, textContent);
        }
    }
}