namespace EasyInjector.Tests.Fakes
{
    using Interfaces;

    public class MixedController
    {
        private readonly IData data;
        private readonly IDependency dependency;

        public MixedController(IData data, Dependency dependency)
        {
            this.data = data;
            this.dependency = dependency;
        }

        public IData Data => this.data;

        public IDependency Dependency => this.dependency;
    }
}
