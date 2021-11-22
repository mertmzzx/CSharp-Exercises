﻿using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                Add(a, b);
            }
            else if (operation =="substract")
            {
                Substract(a,b);
            }
            else if (operation == "multiply")
            {
                Multiply(a,b);
            }
            else
            {
                Divide(a,b);
            }
        }

        static void Add(int a, int b)
        {
            Console.WriteLine($"{a+b}");
        }

        static void Substract( int a, int b)
        {
            Console.WriteLine($"{a-b}");
        }

        static void Multiply(int a, int b)
        {
            Console.WriteLine($"{a*b}");
        }

        static void Divide(int a, int b)
        {
            Console.WriteLine($"{a/b}");
        }
    }
}
