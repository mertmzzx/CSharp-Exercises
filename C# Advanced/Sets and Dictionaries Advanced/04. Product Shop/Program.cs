using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = new Dictionary<string, Dictionary<string, double>>();
            string line = Console.ReadLine();

            while (line != "Revision")
            {
                string shop = line.Split(", ")[0];
                string product = line.Split(", ")[1];
                double price = double.Parse(line.Split(", ")[2]);

                AddProduct(prices, shop, product, price);

                line = Console.ReadLine();
            }

            PrintPrices(prices);
        }

        static void AddProduct(Dictionary<string, Dictionary<string, double>> prices, string shop, string product, double price)
        {
            if (!prices.ContainsKey(shop))
                prices.Add(shop, new Dictionary<string, double>());
            prices[shop][product] = price;
        }

        static void PrintPrices(Dictionary<string, Dictionary<string, double>> prices)
        {
            foreach (var shopAndProducts in prices.OrderBy(sp => sp.Key))
            {
                string shopName = shopAndProducts.Key;
                Console.WriteLine(shopName + "->");
                var products = shopAndProducts.Value;

                foreach (var productAndPrice in products)
                {
                    Console.WriteLine($"Product: {productAndPrice.Key}, Price: {productAndPrice.Value} ");
                }
            }
        }
    }
}
