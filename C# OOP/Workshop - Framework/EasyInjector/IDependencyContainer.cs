namespace EasyInjector
{
    public interface IDependencyContainer
    {
        TDependency Get<TDependency>()
            where TDependency : class;

        TInstance Resolve<TInstance>()
            where TInstance : class;
    }
}
