using System;

namespace _01_
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            string result = age <= 2 ? "baby" : age > 2 && age <= 13 ? "child" : age > 13 && age <= 19 ? "teenager" : age > 19 && age <= 65 ? "adult" : "elder";
            
            Console.WriteLine(result);

            //switch (age)
            //{
            //    case int num when num <= 2:
            //        Console.WriteLine("baby");
            //        break;
            //    case int num when num > 2 && num <= 13:
            //        Console.WriteLine("child");
            //        break;
            //    case int num when num > 13 && num <= 19:
            //        Console.WriteLine("teenager");
            //        break;
            //    case int num when num > 19 && num <= 65:
            //        Console.WriteLine("adult");
            //        break;
            //    default:
            //        Console.WriteLine("elder");
            //        break;
            //}       
        }
    }
}
