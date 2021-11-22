using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string username = command[1];

                if (command[0] == "register")
                {
                    string licensePlate = command[2];

                    if (!users.ContainsKey(username))
                    {
                        users[username] = licensePlate;
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[username]}");
                    }
                }
                else
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
