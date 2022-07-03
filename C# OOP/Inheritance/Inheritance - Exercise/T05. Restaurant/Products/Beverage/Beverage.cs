using System;
using System.Collections.Generic;
using System.Text;
using T05._Restaurant.Products;

namespace T05._Restaurant.Beverage
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            Milliliters = milliliters;
        }

        public double Milliliters { get; set; }
    }
}
