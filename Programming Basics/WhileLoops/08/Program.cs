using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int course = 1;
            int failedCourses = 0;
            double grade = 0.0;
            double gradesSum = 0.0;

            while (course <= 12)
            {
                grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    if (failedCourses > 0)
                    {
                        Console.WriteLine($"{name} has been excluded at {--course} grade");
                        break;
                    }

                    failedCourses++;
                }

                gradesSum += grade;
                course++;
            }

            gradesSum = gradesSum / 12;

            if (failedCourses == 0)
            {
                Console.WriteLine($"{name} graduated. Average grade: {gradesSum:F2}");
            }
        }
    }
}
