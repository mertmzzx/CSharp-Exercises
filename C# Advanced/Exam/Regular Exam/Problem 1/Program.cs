using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] greyTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> grey = new Queue<int>(greyTiles);
            Stack<int> white = new Stack<int>(whiteTiles);

            SortedDictionary<string, int> locations = new SortedDictionary<string, int>()
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor", 0}
            };

            while (true)
            {
                int firstGrey = grey.Peek();
                int lastWhite = white.Peek();
                int largerTile = 0;

                if (firstGrey == lastWhite)
                {
                    largerTile = firstGrey + lastWhite;

                    if (largerTile == 40)
                    {
                        locations["Sink"]++;
                        grey.Dequeue();
                        white.Pop();
                    }
                    else if (largerTile == 50)
                    {
                        locations["Oven"]++;
                        grey.Dequeue();
                        white.Pop();
                    }
                    else if (largerTile == 60)
                    {
                        locations["Countertop"]++;
                        grey.Dequeue();
                        white.Pop();
                    }
                    else if (largerTile == 70)
                    {
                        locations["Wall"]++;
                        grey.Dequeue();
                        white.Pop();
                    }
                    else
                    {
                        locations["Floor"]++;
                        white.Pop();
                        grey.Dequeue();
                    }
                }
                else
                {
                    lastWhite = lastWhite / 2;
                    white.Pop();
                    grey.Dequeue();

                    white = new Stack<int>(white.Reverse());
                    white.Push(lastWhite);
                    white = new Stack<int>(white.Reverse());
                    grey.Enqueue(firstGrey);
                }

                if (white.Count <= 0)
                {
                    break;
                }

                if (grey.Count <= 0)
                {
                    break;
                }
            }

            if (white.Count > 0)
            {
                Console.WriteLine("White tiles left: " + string.Join(", ", white));
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (grey.Count > 0)
            {
                Console.WriteLine("Grey tiles left: " + string.Join(", ", grey));
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var location in locations.OrderByDescending(x => x.Value))
            {
                if (location.Value > 0)
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }
        }
    }
}
