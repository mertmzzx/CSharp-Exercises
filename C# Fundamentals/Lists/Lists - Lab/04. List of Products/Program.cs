using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                products.Add(input);
            }

            Sorting(products);
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }

        static void Sorting(List<string> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                var min = i;
                for (int j = i+1; j < products.Count; j++)
                {
                    if (products[min].CompareTo(products[j]) > 0)
                    {
                        min = j;
                    }
                }

                var temp = products[min];
                products[min] = products[i];
                products[i] = temp;
            }
        }
    }
}
