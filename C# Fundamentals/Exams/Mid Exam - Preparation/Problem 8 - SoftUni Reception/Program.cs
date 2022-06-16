using System;

namespace Problem_8___SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEficiency = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int studentsPerHour = firstEmployeeEficiency + secondEmployeeEficiency + thirdEmployeeEficiency;
            int hours = (int)Math.Ceiling(students / (double)studentsPerHour);

            if (students % studentsPerHour== 0)
            {
                hours = students / studentsPerHour;
            }
            else if (students % studentsPerHour != 0)
            {
                hours = students / studentsPerHour + 1;
            }

            if (hours > 3 && hours % 3 == 0)
            {
                hours += hours / 3 - 1;
            }
            else if (hours > 3)
            {
                hours += hours / 3;
            }

            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}
