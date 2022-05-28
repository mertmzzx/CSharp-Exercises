using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productsAndPrice = new Dictionary<string, double>();
            Dictionary<string, double> productsAndQuantity = new Dictionary<string, double>();
            string drinks = Console.ReadLine();

            while (drinks != "buy")
            {
                string[] token = drinks.Split();
                string drink = token[0];
                double price = double.Parse(token[1]);
                double quantity = double.Parse(token[2]);

                if (!productsAndQuantity.ContainsKey(drink))
                {
                    productsAndQuantity[drink] = 0;
                }

                productsAndQuantity[drink] += quantity;

                if (!productsAndPrice.ContainsKey(drink))
                {
                    productsAndPrice[drink] = 0;
                }

                productsAndPrice[drink] = price;

                drinks = Console.ReadLine();
            }

            foreach (var kvp in productsAndQuantity)
            {
                string product = kvp.Key;
                double quantity = kvp.Value;
                double price = productsAndPrice[product];
                double result = quantity * price;

                Console.WriteLine($"{product} -> {result:f2}");   
            }
        }
    }
}
