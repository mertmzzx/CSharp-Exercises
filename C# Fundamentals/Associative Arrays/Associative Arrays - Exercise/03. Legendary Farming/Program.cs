using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryItems = new Dictionary<string, int>();
            legendaryItems.Add("shards", 0);
            legendaryItems.Add("motes", 0);
            legendaryItems.Add("fragments", 0);
            var junkMaterials = new Dictionary<string, int>();
            bool isLegendaryFound = false;
            while (!isLegendaryFound)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 1; i < input.Length; i += 2)
                {
                    string keyMaterial = input[i].ToLower(); // shards
                    int valueMaterial = int.Parse(input[i - 1]); // 10
                    if (keyMaterial == "shards" || keyMaterial == "motes" || keyMaterial == "fragments")
                    {
                        legendaryItems[keyMaterial] += valueMaterial;
                        if (legendaryItems[keyMaterial] >= 250)
                        {
                            isLegendaryFound = true;
                            break;
                        }
                    }
                    else if (junkMaterials.ContainsKey(keyMaterial))
                    {
                        junkMaterials[keyMaterial] += valueMaterial;
                    }
                    else
                    {
                        junkMaterials.Add(keyMaterial, valueMaterial);
                    }
                }
            }

            if (legendaryItems["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                legendaryItems["shards"] -= 250;
            }
            else if (legendaryItems["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                legendaryItems["fragments"] -= 250;
            }
            else if (legendaryItems["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                legendaryItems["motes"] -= 250;
            }

            foreach (var keyItem in legendaryItems.OrderByDescending(key => key.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyItem.Key}: {keyItem.Value}");
            }

            foreach (var junkItem in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junkItem.Key}: {junkItem.Value}");
            }
        }
    }
}
