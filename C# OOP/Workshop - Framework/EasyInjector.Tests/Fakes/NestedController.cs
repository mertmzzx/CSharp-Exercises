namespace EasyInjector.Tests.Fakes
{
    using Interfaces;
    public class NestedController
    {
        private readonly INestedDependency nestedDependency;
        private readonly IData data;

        public NestedController(INestedDependency nestedDependency, IData data)
        {
            this.nestedDependency = nestedDependency;
            this.data = data;
        }

        public INestedDependency NestedDependency => this.nestedDependency;

        public IData Data => this.data;
    }
}
