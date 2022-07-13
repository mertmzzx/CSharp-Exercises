using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];
                string[] doughArgs = Console.ReadLine().Split();
                Dough dough = new Dough(doughArgs[1], doughArgs[2], int.Parse(doughArgs[3]));
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppings = Console.ReadLine();
                while (toppings != "END")
                {
                    string type = toppings.Split()[1];
                    int weight = int.Parse(toppings.Split()[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopings(topping);

                    toppings = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
