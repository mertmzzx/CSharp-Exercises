using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7___Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guests = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] plates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> guestsValues = new Queue<int>(guests);
            Stack<int> foodValues = new Stack<int>(plates);

            int wastedFood = 0;

            while (guestsValues.Count > 0 && foodValues.Count > 0)
            {
                int currGuest = guestsValues.Peek();
                int currFood = foodValues.Peek();

                if (currFood >= currGuest)
                {
                    wastedFood += currFood - currGuest;
                    guestsValues.Dequeue();
                    foodValues.Pop();
                }
                else
                {
                    currGuest -= currFood;
                    guestsValues.Dequeue();
                    foodValues.Pop();

                    guestsValues = new Queue<int>(guestsValues.Reverse());
                    guestsValues.Enqueue(currGuest);
                    guestsValues = new Queue<int>(guestsValues.Reverse());
                }

                if (currGuest <= 0)
                {
                    guestsValues.Dequeue();
                }
            }

            if (guestsValues.Count > 0)
            {
                Console.WriteLine($"Guests: " + String.Join(" ", guestsValues));
            }
            else
            {
                Console.WriteLine($"Plates: " + String.Join(" ", foodValues));
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
