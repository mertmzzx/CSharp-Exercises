using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Plant_Discovery
{
    class Program
    {
        public class Plant
        {
            public int rarity;
            public List<double> rates = new List<double>();
            public double averageRating = 0;
            public void addRate(double rate)
            {
                averageRating = 0;
                rates.Add(rate);
                for (int i = 0; i < rates.Count; i++)
                {
                    averageRating += rates[i];
                }
                averageRating = averageRating / rates.Count;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> dict = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string plant = Console.ReadLine();
                string[] plantsPart = plant.Split("<->");

                if (dict.ContainsKey(plantsPart[0]))
                {
                    dict[plantsPart[0]].rarity = int.Parse(plantsPart[1]);
                }
                else
                {
                    Plant currPlant = new Plant();
                    currPlant.rarity = int.Parse(plantsPart[1]);
                    dict.Add(plantsPart[0], currPlant);
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                string[] values = command.Split();
                if (values[0].Contains("Rate"))
                {
                    if (dict.ContainsKey(values[1]))
                    {
                        dict[values[1]].addRate(double.Parse(values[3]));
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (values[0].Contains("Update"))
                {
                    if (dict.ContainsKey(values[1]))
                    {
                        dict[values[1]].rarity = int.Parse(values[3]);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (values[0].Contains("Reset"))
                {
                    if (dict.ContainsKey(values[1]))
                    {
                        dict[values[1]].rates.Clear();
                        dict[values[1]].averageRating = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in dict.OrderByDescending(x => x.Value.rarity).ThenByDescending(x => x.Value.averageRating))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.rarity}; Rating: {item.Value.averageRating:f2}");
            }
        }
    }
}
