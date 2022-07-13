using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppingTypeCalories = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9},
        };
        private string toppingType;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Calories => 2 * this.Weight * toppingTypeCalories[this.Type.ToLower()];
        public string Type
        {
            get => this.toppingType;
            private set
            {
                if (toppingTypeCalories.ContainsKey(value.ToLower()))
                {
                    this.toppingType = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public int Weight 
        { 
            get => this.weight;
            private set
            {
                if (value >= 1 && value <= 50)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
            }
        }
    }
}
