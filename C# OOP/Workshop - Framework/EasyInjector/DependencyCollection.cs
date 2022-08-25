namespace EasyInjector
{
    using System;
    using System.Collections.Generic;

    public class DependencyCollection
    {
        private readonly Dictionary<Type, Type> dependencyRegistrations;

        public DependencyCollection()
        {
            this.dependencyRegistrations = new Dictionary<Type, Type>();
        }

        public void Register<TDependency, TImplementation>()
            where TImplementation : TDependency
        {
            var dependencyType = typeof(TDependency);
            var implementationType = typeof(TImplementation);

            this.dependencyRegistrations[dependencyType] = implementationType;
        }

        public void RegisterAllFrom<TAssembly>()
            where TAssembly : class
        {
            var allTypes = typeof(TAssembly)
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in allTypes)
            {
                var sameNameInterface = type
                    .GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{type.Name}");

                if (sameNameInterface != null)
                {
                    this.dependencyRegistrations[sameNameInterface] = type;
                }
            }
        }

        public IDependencyContainer BuildContainer()
            => new DependencyContainer(this.dependencyRegistrations);
    }
}
