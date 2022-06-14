using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(orders.Max().ToString());

            bool isExitLoop = false;

            while (!isExitLoop)
            {
                if (orders.Count > 0)
                {
                    if (quantityFood - orders.Peek() >= 0)
                    {
                        quantityFood -= orders.Dequeue();
                    }
                    else
                    {
                        isExitLoop = true;
                    }
                }
                else
                {
                    isExitLoop = true;
                }
            }

            if (orders.Count > 0)
            {
                sb.AppendLine($"Orders left: {string.Join(' ', orders)}");
            }
            else
            {
                sb.AppendLine("Orders complete");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
