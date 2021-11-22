using System;
using System.Linq;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = new string(username.ToCharArray().Reverse().ToArray());
            
            //string password = string.Empty;
            //
            //for (int i = username.Length - 1; i >= 0; i--)
            //{
            //    password += username[i];
            //}

            int tries = 0;
            string input = Console.ReadLine();

            while (input != password)
            {
                tries++;

                if (tries >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
          
        }
    }
}
