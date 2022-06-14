using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger lastSnowballValue = 0;
            BigInteger lastSnowballSnow = 0;
            BigInteger lastSnowballTime = 0;
            BigInteger lastSnowballQuality = 0;

            BigInteger snowballSnow = 0;
            BigInteger snowballTime = 0;
            BigInteger snowballQuality = 0;

            for (int i = 0; i < number; i++)
            {
                snowballSnow = BigInteger.Parse(Console.ReadLine());
                snowballTime = BigInteger.Parse(Console.ReadLine());
                snowballQuality = BigInteger.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, (int)snowballQuality);

                if (snowballValue > lastSnowballValue)
                {
                    lastSnowballValue = snowballValue;
                    lastSnowballSnow = snowballSnow;
                    lastSnowballTime = snowballTime;
                    lastSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{lastSnowballSnow} : {lastSnowballTime} = {lastSnowballValue} ({lastSnowballQuality})");
        }
    }
}
