namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class SaltwaterFish : Fish
    {
        private const int SaltwaterFishInitialSize = 5;
        private const int SaltwaterFishIncrSize = 2;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = SaltwaterFishInitialSize;
        }

        public override void Eat()
        {
            this.Size += SaltwaterFishIncrSize;
        }
    }
}
