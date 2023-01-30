namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)this.models;
        public void AddItem(IWeapon model) => this.models.Add(model);

        public IWeapon FindByName(string name) => this.models.FirstOrDefault(m => m.GetType().Name == name);

        public bool RemoveItem(string name) =>
            this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == name));
    }
}
