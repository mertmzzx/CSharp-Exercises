using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVAT = x => x * 1.20m;

            string input = Console.ReadLine();
            string[] tokens = input.Split(", ");
            decimal[] nums = tokens.Select(decimal.Parse).ToArray();
            decimal[] numsWithVAT = nums.Select(addVAT).ToArray();

            //foreach (var n in numsWithVAT)
            //{
            //    Console.WriteLine("{0:f2}", n);
            //}

            //Array.ForEach(numsWithVAT, x => Console.WriteLine("{0:f2}", x));

            numsWithVAT.ToList().ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
