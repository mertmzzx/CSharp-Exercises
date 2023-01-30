namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)this.models;
        public void AddItem(IMilitaryUnit model) => this.models.Add(model);

        public IMilitaryUnit FindByName(string name) => this.models.FirstOrDefault(m => m.GetType().Name == name);

        public bool RemoveItem(string name) => this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == name));
    }
}
