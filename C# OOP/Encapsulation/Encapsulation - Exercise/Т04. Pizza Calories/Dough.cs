using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1},
        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1},
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Calories => 2 * this.Weight * flourTypeCalories[this.FlourType.ToLower()] * bakingTechniqueCalories[this.BakingTechnique.ToLower()];

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value != null && flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value != null && bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value >= 1 && value <= 200)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
    }
}
