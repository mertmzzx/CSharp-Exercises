﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person(20);

            Console.WriteLine($"Person Name: {person.Name}{Environment.NewLine}Person Age:{person.Age}");
        }
    }
}