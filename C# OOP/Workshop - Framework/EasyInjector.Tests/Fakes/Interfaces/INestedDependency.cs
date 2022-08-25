namespace EasyInjector.Tests.Fakes.Interfaces
{
    public interface INestedDependency
    {
        IData Data { get; }

        IDependency Dependency { get; }
    }
}
