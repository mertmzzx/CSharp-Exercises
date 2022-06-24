using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10___The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] plates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> platesValue = new Queue<int>(plates);
            Stack<int> orcsValue = new Stack<int>();
            
            for (int i = 1; i <= n; i++)
            {
                if (platesValue.Count <= 0)
                {
                    break;
                }

                int[] orcs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                foreach (var orc in orcs)
                {
                    orcsValue.Push(orc);
                }
                if (i % 3 == 0)
                {
                    int extraLine = int.Parse(Console.ReadLine());
                    platesValue.Enqueue(extraLine);
                }

                
                while (orcsValue.Count > 0 && platesValue.Count > 0)
                {
                    int lastOrc = orcsValue.Peek();
                    int firstPlate = platesValue.Peek();

                    if (lastOrc > firstPlate)
                    {
                        lastOrc -= firstPlate;
                        orcsValue.Pop();
                        platesValue.Dequeue();

                        orcsValue = new Stack<int>(orcsValue.Reverse());
                        orcsValue.Push(lastOrc);
                        orcsValue = new Stack<int>(orcsValue.Reverse());
                    }
                    else if (firstPlate > lastOrc)
                    {
                        firstPlate -= lastOrc;
                        orcsValue.Pop();
                        platesValue.Dequeue();

                        platesValue = new Queue<int>(platesValue.Reverse());
                        platesValue.Enqueue(firstPlate);
                        platesValue = new Queue<int>(platesValue.Reverse());
                    }
                    else if (lastOrc == firstPlate)
                    {
                        orcsValue.Pop();
                        platesValue.Dequeue();
                    }
                }
            }

            if (orcsValue.Count > platesValue.Count)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }

            if (platesValue.Count > 0)
            {
                Console.WriteLine("Plates left: " + String.Join(", ", platesValue));
            }
            else
            {
                Console.WriteLine("Orcs left: " + String.Join(", ", orcsValue));
            }
        }
    }
}
