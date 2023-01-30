namespace NavalVessels.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            this.models = new HashSet<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)this.models;

        public void Add(IVessel model) => this.models.Add(model);

        public bool Remove(IVessel model) => this.models.Remove(model);

        public IVessel FindByName(string name) => this.models.FirstOrDefault(v => v.Name == name);
    }
}
