namespace EasyInjector.Tests.Fakes
{
    using Interfaces;

    public class Controller
    {
        private readonly IData data;
        private readonly IDependency dependency;

        public Controller(IData data, IDependency dependency)
        {
            this.data = data;
            this.dependency = dependency;
        }

        public IData Data => this.data;

        public IDependency Dependency => this.dependency;
    }
}
