using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value != null)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
            }
        }
        public decimal Cost 
        {
            get => this.cost;
            set
            {
                if (value >= 0)
                {
                    this.cost = value;
                }
                else
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }
    }
}
