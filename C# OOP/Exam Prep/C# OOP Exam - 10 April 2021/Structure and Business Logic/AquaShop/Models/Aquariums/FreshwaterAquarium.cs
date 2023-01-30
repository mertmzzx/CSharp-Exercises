namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FreshwaterAquarium : Aquarium
    {
        private const int FreshwaterAquariumInitialCapacity = 50;

        public FreshwaterAquarium(string name) : base(name, FreshwaterAquariumInitialCapacity)
        {
        }
    }
}
