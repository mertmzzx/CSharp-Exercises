namespace EasyInjector.Tests.Fakes
{
    using Interfaces;

    public class NestedDependency : INestedDependency
    {
        private readonly IData data;
        private readonly IDependency dependency;

        public NestedDependency(IData data, IDependency dependency)
        {
            this.data = data;
            this.dependency = dependency;
        }
        public IData Data => this.data;

        public IDependency Dependency => this.dependency;
    }
}
