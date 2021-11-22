using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double fatPercent = double.Parse(Console.ReadLine());
            double proteinPercent = double.Parse(Console.ReadLine());
            double carbsPercent = double.Parse(Console.ReadLine());
            double totalCalories = double.Parse(Console.ReadLine());
            double waterPercent = double.Parse(Console.ReadLine());

            fatPercent = fatPercent / 100;
            proteinPercent = proteinPercent / 100;
            carbsPercent = carbsPercent / 100;

            double totalFat = (totalCalories * fatPercent) / 9;
            double totalProtein = (totalCalories * proteinPercent) / 4;
            double totalCarbs = (totalCalories * carbsPercent) / 4;

            double totalFood = totalProtein + totalFat + totalCarbs;
            double caloriesPerGram = totalCalories / totalFood;
            double FoodWithoutWater = ((100 - waterPercent) / 100) * caloriesPerGram;

            Console.WriteLine($"{FoodWithoutWater:F4}");
        }
    }
}
