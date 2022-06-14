using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            int pokeCount = 0;
            double fiftyPercent = power * 0.5;

            while (power >= distance)
            {
                pokeCount++;
                power -= distance;

                if (power == fiftyPercent && Y != 0)
                {
                    power /= Y;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(pokeCount);

        }
    }
}
