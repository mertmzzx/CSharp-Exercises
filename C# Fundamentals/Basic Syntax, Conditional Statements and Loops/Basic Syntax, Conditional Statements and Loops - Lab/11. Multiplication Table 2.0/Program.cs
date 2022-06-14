using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{number} X {multiplier} = {number * multiplier}");
                multiplier++;
            } while (multiplier <= 10);            
        }
    }
}
