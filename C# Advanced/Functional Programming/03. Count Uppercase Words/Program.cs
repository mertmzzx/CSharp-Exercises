using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main() =>
            Console.WriteLine(
                String.Join(
                    "\r\n",
                    Console.ReadLine()
                        .Split(" ")
                        .Where(isFirstLetterCapital)
                )
            );

        static Func<string, bool> isFirstLetterCapital = x => x.Length > 0 && char.IsUpper(x[0]);
    }
}
