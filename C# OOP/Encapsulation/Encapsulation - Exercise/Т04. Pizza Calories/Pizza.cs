using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public double TotalCalories => Dough.Calories + toppings.Sum(x => x.Calories);

        public string Name 
        {
            get => this.name; 
            private set
            {
                if (value != null && value.Length > 1 && value.Length < 15)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }
        public Dough Dough { get; set; }
        public IReadOnlyCollection<Topping> Toppings => this.toppings;

        public void AddTopings(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                toppings.Add(topping);
            }
        }

    }
}
