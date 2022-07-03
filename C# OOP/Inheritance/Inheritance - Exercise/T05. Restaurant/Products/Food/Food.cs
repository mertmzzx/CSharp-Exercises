using System;
using System.Collections.Generic;
using System.Text;
using T05._Restaurant.Products;

namespace T05._Restaurant.Food
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }

        public double Grams { get; set; }
    }
}
