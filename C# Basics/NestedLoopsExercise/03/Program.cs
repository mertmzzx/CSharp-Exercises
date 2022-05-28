using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int num;

            int primeSum = 0;
            int nonPrimeSum = 0;

            while (input != "stop")
            {
                num = int.Parse(input);

                bool nonPrime = false;

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    if (num == 0 || num == 1)
                    {
                        nonPrimeSum += num;
                    }
                    else
                    {
                        for (int i = 2; i <= num / 2; i++)
                        {
                            if (num % i == 0)
                            {
                                nonPrime = true;
                                nonPrimeSum += num;
                                break;
                            }
                        }
                        if (nonPrime == false)
                        {
                            primeSum += num;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
