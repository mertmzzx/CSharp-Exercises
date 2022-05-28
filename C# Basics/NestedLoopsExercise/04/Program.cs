using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentAverage = 0.0;
            double finalAssessment = 0.0;

            int jury = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double mark = 0.0;
            int votes = 0;
            int presentations = 0;

            while (presentationName != "Finish")
            {
                while (votes != jury)
                {
                    mark += double.Parse(Console.ReadLine());
                    votes++;
                }

                currentAverage = mark / votes;
                finalAssessment += currentAverage;

                mark = 0;
                votes = 0;

                Console.WriteLine($"{presentationName} - {currentAverage:F2}.");

                presentations++;
                presentationName = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {finalAssessment / presentations:F2}.");
        }
    }
}
