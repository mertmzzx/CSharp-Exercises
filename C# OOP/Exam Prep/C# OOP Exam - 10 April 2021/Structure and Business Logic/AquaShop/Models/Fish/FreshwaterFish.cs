namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FreshwaterFish : Fish
    {
        private const int FreshwaterFishInitialSize = 3;
        private const int FreshwaterFishIncrSize = 3;

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = FreshwaterFishInitialSize;
        }

        public override void Eat()
        {
            this.Size += FreshwaterFishIncrSize;
        }
    }
}
