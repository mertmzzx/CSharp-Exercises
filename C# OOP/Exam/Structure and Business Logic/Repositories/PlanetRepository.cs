namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)this.models;
        public void AddItem(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);

        public bool RemoveItem(string name) =>
            this.models.Remove(this.models.FirstOrDefault(m => m.Name == name));
    }
}
