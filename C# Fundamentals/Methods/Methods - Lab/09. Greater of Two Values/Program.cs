using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (type == "int")
            {
                int result = intGetMax(a, b);
                Console.WriteLine(result);
            }
            else if (type == "char")
            {
                char result = charGetMax(a, b);
                Console.WriteLine(result);
            }
            else
            {
                string result = stringGetMax(a, b);
                Console.WriteLine(result);
            }
        }

        static int intGetMax(string a, string b)
        {
            int n1 = int.Parse(a);
            int n2 = int.Parse(b);

            if (n1 > n2)
            {
                return n1;
            }
            else
            {
                return n2;
            }
        }

        static char charGetMax(string a, string b)
        {
            char n1 = char.Parse(a);
            char n2 = char.Parse(b);

            if (n1 > n2)
            {
                return n1;
            }
            else
            {
                return n2;
            }
        }
        static string stringGetMax(string a, string b)
        {


            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
