using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class HolidaysBetweenTwoDates
{

    class AnimalInfo
    {
        public int neededFood { get; set; }

        public string area { get; set; }
    }
    static void Main()
    {
        Dictionary<string, AnimalInfo> animals = new Dictionary<string, AnimalInfo>();
        Dictionary<string, int> areaPopulation = new Dictionary<string, int>();
        string[] commands = Console.ReadLine().Split(": ");
        while (commands[0] != "EndDay")
        {
            string[] input = commands[1].Split("-");
            if (commands[0] == "Add")
            {
                string animalName = input[0];
                int neededFood = int.Parse(input[1]);
                string area = input[2];

                if (!animals.ContainsKey(animalName))
                {
                    AnimalInfo animal = new AnimalInfo();
                    animal.area = area;
                    animal.neededFood = neededFood;
                    animals[animalName] = animal;
                    if (!areaPopulation.ContainsKey(area))
                    {
                        areaPopulation[area] = 1;
                    }
                    else
                    {
                        areaPopulation[area] += 1;
                    }
                }
                else
                {
                    animals[animalName].neededFood += neededFood;
                }
            }
            else if (commands[0] == "Feed")
            {
                string animalName = input[0];
                int feedingWith = int.Parse(input[1]);
                if (animals.ContainsKey(animalName))
                {
                    animals[animalName].neededFood -= feedingWith;
                    if (animals[animalName].neededFood <= 0)
                    {
                        areaPopulation[animals[animalName].area] -= 1;
                        animals.Remove(animalName);
                        Console.WriteLine($"{animalName} was successfully fed");
                    }
                }
            }
            commands = Console.ReadLine().Split(": ");
        }
        Console.WriteLine("Animals:");
        foreach (var item in animals.OrderByDescending(a => a.Value.neededFood).ThenBy(a => a.Key))
        {
            Console.WriteLine($" {item.Key} -> {item.Value.neededFood}g");
        }
        Console.WriteLine("Areas with hungry animals:");
        foreach (var item in areaPopulation.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
        {
            if (item.Value > 0)
            {
                Console.WriteLine($" {item.Key}: {item.Value}");
            }
        }
    }
}