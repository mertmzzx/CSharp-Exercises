using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployer = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] token = command.Split(" -> ");
                string companyName = token[0];
                string employeeID = token[1];

                if (!companyEmployer.ContainsKey(companyName))
                {
                    companyEmployer.Add(companyName, new List<string>() { employeeID });
                }
                else
                {
                    if (!companyEmployer[companyName].Contains(employeeID))
                    {
                        companyEmployer[companyName].Add(employeeID);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var company in companyEmployer.OrderBy(company => company.Key))
            {
                Console.WriteLine(company.Key);

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");   
                }
            }
        }
    }
}
