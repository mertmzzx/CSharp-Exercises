using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
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
        public decimal Money 
        {
            get => this.money;
            set
            {
                if (value >= 0)
                {
                    this.money = value;
                }
                else
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }
        public ICollection<Product> BagOfProducts { get; set; }

        public override string ToString()
        {
            return this.BagOfProducts.Count > 0 
                ? $"{this.Name} - {string.Join(", ", BagOfProducts.Select(p => p.Name))}" 
                : $"{this.Name} - Nothing bought";
        }
    }
}
