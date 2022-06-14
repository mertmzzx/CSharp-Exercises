using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersOcc = new Dictionary<int, int>();

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersOcc.ContainsKey(number))
                {
                    numbersOcc.Add(number, 1);
                }
                else
                {
                    numbersOcc[number]++;
                }
            }

            Console.WriteLine(numbersOcc.First(entry => entry.Value % 2 == 0).Key);
        }
    }
}
