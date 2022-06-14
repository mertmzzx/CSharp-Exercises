using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            
            string biggestKeg = "";
            double lastVolume = 0.0;
            double volume = 0.0;

            for (int i = 0; i < lines; i++)
            {
                string keg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                volume = Math.PI * radius * radius * height;

                if (volume > lastVolume)
                {
                    biggestKeg = keg;
                    lastVolume = volume;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
