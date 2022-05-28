using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            double exchange = double.Parse(Console.ReadLine()) * 100;
            int coins = 0;

            while (exchange > 0)
            {
                if (exchange / 200 >= 1)
                {
                    exchange -= 200;
                    coins++;
                }
                else if (exchange / 100 >= 1)
                {
                    exchange -= 100;
                    coins++;
                }
                else if (exchange / 50 >= 1)
                {
                    exchange -= 50;
                    coins++;
                }
                else if (exchange / 20 >= 1)
                {
                    exchange -= 20;
                    coins++;
                }
                else if (exchange / 10 >= 1)
                {
                    exchange -= 10;
                    coins++;
                }
                else if (exchange / 5 >= 1)
                {
                    exchange -= 5;
                    coins++;
                }
                else if (exchange / 2 >= 1)
                {
                    exchange -= 2;
                    coins++;
                }
                else if (exchange / 1 >= 1)
                {
                    exchange -= 1;
                    coins++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(coins);
        }
    }
}
