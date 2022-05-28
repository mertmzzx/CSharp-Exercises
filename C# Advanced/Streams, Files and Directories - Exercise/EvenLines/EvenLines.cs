namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            ProcessLines(inputFilePath);
        }

        public static void ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = -1; //брой редовете
                string line = reader.ReadLine(); //четем по 1 ред от файла

                while (line != null)
                {
                    counter++;
                    if (counter % 2 == 0)
                    {
                        //замяна
                        line = Replace(line);
                        //обърна в обратен ред
                        line = Reverse(line);
                        Console.WriteLine(line);
                    }

                    line = reader.ReadLine();
                }
            }
        }

        private static string Reverse(string line)
        {
            return string.Join(" ", line.Split().Reverse());
        }

        private static string Replace(string line) //върне реда със заместени символи
        {
            return line.Replace("-", "@")
                 .Replace(",", "@")
                 .Replace(".", "@")
                 .Replace("!", "@")
                 .Replace("?", "@");
        }
    }
}