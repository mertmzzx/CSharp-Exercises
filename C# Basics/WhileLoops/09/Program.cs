using System;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            int spaceWidth = int.Parse(Console.ReadLine());
            int spaceLength = int.Parse(Console.ReadLine());
            int spaceHeigth = int.Parse(Console.ReadLine());
            string boxes = Console.ReadLine();
            
            bool space = true;
            
            int roomSpace = 0;
            int boxesSpace = 0;

            while (boxes != "Done")
            {
                int currentBoxes = int.Parse(boxes);

                roomSpace = spaceHeigth * spaceWidth * spaceLength;
                boxesSpace += currentBoxes;

                if (boxesSpace > roomSpace)
                {
                    Console.WriteLine($"No more free space! You need {boxesSpace - roomSpace} Cubic meters more.");
                    space = false;
                    break;
                }

                boxes = Console.ReadLine();
            }

            if (space == true)
            {
            Console.WriteLine($"{roomSpace - boxesSpace} Cubic meters left.");
            }
        }
    }
}
