namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        private Aquarium()
        {
            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();
        }

        protected Aquarium(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }
        public int Comfort => this.Decorations.Sum(x => x.Comfort);
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }
        public void AddDecoration(IDecoration decoration) => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }
        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string fishOutput = this.Fish.Count > 0 ? 
                string.Join(", ", this.Fish.Select(f => f.Name)) 
                : "none";

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishOutput}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString();
        }
    }
}
