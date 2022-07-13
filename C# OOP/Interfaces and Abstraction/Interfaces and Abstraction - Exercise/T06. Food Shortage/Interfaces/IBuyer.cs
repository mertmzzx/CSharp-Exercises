using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        public int Food { get; set; }

        public void BuyFood(string name);
    }
}
