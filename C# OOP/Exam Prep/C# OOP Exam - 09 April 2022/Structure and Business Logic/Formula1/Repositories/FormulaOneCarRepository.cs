namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new HashSet<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.models;
        public void Add(IFormulaOneCar model) => this.models.Add(model);

        public bool Remove(IFormulaOneCar model) => this.models.Remove(model);

        public IFormulaOneCar FindByName(string name) => this.models.FirstOrDefault(m => m.Model == name);
    }
}
