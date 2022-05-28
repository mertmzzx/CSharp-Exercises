using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int cakeSize = width * length;
            int piecesSize = 0;

            string pieceOfCake = Console.ReadLine();

            while (cakeSize > 0 && pieceOfCake != "STOP")
            {
                int pieces = int.Parse(pieceOfCake);

                cakeSize -= pieces;

                pieceOfCake = Console.ReadLine();
            }

            if (cakeSize < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeSize)} pieces more.");
            }
            else if (pieceOfCake == "STOP")
            {
                Console.WriteLine($"{cakeSize} pieces are left.");
            }
        }
    }
}
