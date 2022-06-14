using System;
using System.Collections.Generic;

namespace T01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
