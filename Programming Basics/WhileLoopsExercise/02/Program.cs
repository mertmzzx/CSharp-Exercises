using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFails = int.Parse(Console.ReadLine());
            string exerciseName = "";
            int grade = 0;
            double gradesSum = 0.00;
            string lastProblem = "";
            int exerciseCounter = 0;
            int problemCounter = 0;

            while (true)
            {
                exerciseName = Console.ReadLine();

                if (exerciseName == "Enough")
                {
                    gradesSum = gradesSum / exerciseCounter;
                    Console.WriteLine($"Average score: {gradesSum:F2}");
                    Console.WriteLine($"Number of problems: {exerciseCounter}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }

                grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    problemCounter++;
                }

                if (problemCounter >= numberFails)
                {
                    Console.WriteLine($"You need a break, {problemCounter} poor grades.");
                    break;
                }

                lastProblem = exerciseName;
                gradesSum += grade;
                exerciseCounter++;
            }

        }
    }
}
