namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;

        public PilotRepository()
        {
            this.models = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.models;
        public void Add(IPilot model) => this.models.Add(model);

        public bool Remove(IPilot model) => this.models.Remove(model);

        public IPilot FindByName(string name) => this.models.FirstOrDefault(m => m.FullName == name);
    }
}
