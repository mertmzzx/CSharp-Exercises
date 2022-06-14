using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] token = command.Split(" : ").ToArray();
                string courseName = token[0];
                string student = token[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>(){student});
                }
                else
                {
                    courses[courseName].Add(student);
                }

                command = Console.ReadLine();
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var students in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {students}");
                }
            }
        }
    }
}
