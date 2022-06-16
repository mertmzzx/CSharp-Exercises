using System;
using System.Text.RegularExpressions;

namespace Problem_2___Encrypting_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                string password = "";

                if (match.Success)
                {

                    for (int j = 2; j <= 5; j++)
                    {
                        password += match.Groups[j].Value;
                    }

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
