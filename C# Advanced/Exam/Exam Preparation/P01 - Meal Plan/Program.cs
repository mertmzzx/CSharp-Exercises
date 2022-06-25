using System;
using System.Collections.Generic;
using System.Linq;

public class MealPlan
{
    static void Main()
    {
        Dictionary<string, int> caloriesByMeal = new Dictionary<string, int>()
        {
            { "salad", 350 },
            { "soup",  490 },
            { "pasta", 680 },
            { "steak", 790 },
        };
        string[] meals = Console.ReadLine().Split(" ");
        int mealsSum = meals.Select(m => caloriesByMeal[m]).Sum();

        Stack<int> daysStack =
            new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
        int daysSum = daysStack.Sum();

        for (int mealIndex = 0; mealIndex < meals.Length; mealIndex++)
        {
            string meal = meals[mealIndex];
            int mealCals = caloriesByMeal[meal];

            var dayCals = daysStack.Pop();
            int calsLeft = dayCals - mealCals;
            if (calsLeft > 0)
                daysStack.Push(calsLeft);
            else if (calsLeft < 0)
            {
                if (daysStack.Count == 0)
                {
                    // All limits are eaten --> print the left meals
                    Console.WriteLine($"John ate enough, he had {mealIndex + 1} meals.");
                    var mealsLeft = new List<string>();
                    for (int i = mealIndex + 1; i < meals.Length; i++)
                    {
                        mealsLeft.Add(meals[i]);
                    }
                    Console.WriteLine($"Meals left: {string.Join(", ", mealsLeft)}.");
                    return;
                }
                var prevDayCals = daysStack.Pop();
                calsLeft = prevDayCals + calsLeft;
                daysStack.Push(calsLeft);
            }
        }

        // All meals are eaten --> print the days left
        Console.WriteLine($"John had {meals.Length} meals.");
        var daysLeft = string.Join(", ", daysStack);
        Console.WriteLine($"For the next few days, he can eat {daysLeft} calories.");
    }
}