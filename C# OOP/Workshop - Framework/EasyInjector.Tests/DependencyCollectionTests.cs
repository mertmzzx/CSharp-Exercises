namespace EasyInjector.Tests
{
    using EasyInjector.Tests.Fakes.Interfaces;

    public class DependencyCollectionTests
    {
        [Test]
        public void RegisteringDependencyShouldAllowResolvingItToAnImplementation()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();
            dependencyCollection.Register<IData, Data>();
            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var data = dependencyContainer.Get<IData>();

            // Assert
            Assert.That(data, Is.TypeOf<Data>());
        }

        [Test]
        public void GettingInvalidDependencyShouldThrowAnException()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();
            var dependencyContainer = dependencyCollection.BuildContainer();

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                var data = dependencyContainer.Get<IData>();
            }, "EasyInjector.Tests.Fakes.IData is not registered in the dependency container!");
        }

        [Test]
        public void GettingMultipleDependenciesShouldWorkCorrectly()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();
            dependencyCollection.Register<IData, Data>();
            dependencyCollection.Register<IDependency, Dependency>();
            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var data = dependencyContainer.Get<IData>();
            var dependency = dependencyContainer.Get<IDependency>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.TypeOf<Data>());
                Assert.That(dependency, Is.TypeOf<Dependency>());
            });
        }

        [Test]
        public void RegisteringTheSameInterfaceShouldResolveTheLastOne()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();
            dependencyCollection.Register<IDependency, Dependency>();
            dependencyCollection.Register<IDependency, SecondDependency>();
            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var dependency = dependencyContainer.Get<IDependency>();

            // Assert
            Assert.That(dependency, Is.TypeOf<SecondDependency>());
        }

        [Test]
        public void ResolvingClassWithCtorDependenciesShouldWorkCorrectly()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();
            dependencyCollection.Register<IData, Data>();
            dependencyCollection.Register<IDependency, Dependency>();
            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var controller = dependencyContainer.Resolve<Controller>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(controller.Data, Is.TypeOf<Data>());
                Assert.That(controller.Dependency, Is.TypeOf<Dependency>());
            });
        }

        [Test]
        public void ResolvingNestedDependenciesWithConstructorShouldWorkCorrectly()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();

            dependencyCollection.Register<IData, Data>();
            dependencyCollection.Register<IDependency, Dependency>();
            dependencyCollection.Register<INestedDependency, NestedDependency>();

            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var controller = dependencyContainer.Resolve<NestedController>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(controller.Data, Is.TypeOf<Data>());
                Assert.That(controller.NestedDependency, Is.TypeOf<NestedDependency>());
                Assert.That(controller.NestedDependency.Dependency, Is.TypeOf<Dependency>());
                Assert.That(controller.NestedDependency.Data, Is.TypeOf<Data>());
            });
        }

        [Test]
        public void ResolvingMixedConstructorShouldWorkCorrectly()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();

            dependencyCollection.Register<IData, Data>();

            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var controller = dependencyContainer.Resolve<MixedController>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(controller.Data, Is.TypeOf<Data>());
                Assert.That(controller.Dependency, Is.TypeOf<Dependency>());
            });
        }

        [Test]
        public void ResolvingAutomaticDependenciesShouldWorkCorrectly()
        {
            // Arrange
            var dependencyCollection = new DependencyCollection();

            dependencyCollection.RegisterAllFrom<DependencyCollectionTests>();

            dependencyCollection.Register<IDependency, ManualDependency>();

            var dependencyContainer = dependencyCollection.BuildContainer();

            // Act
            var data = dependencyContainer.Get<IData>();
            var dependency = dependencyContainer.Get<IDependency>();
            var nestedDependency = dependencyContainer.Get<INestedDependency>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.TypeOf<Data>());
                Assert.That(dependency, Is.TypeOf<ManualDependency>());
                Assert.That(nestedDependency, Is.TypeOf<NestedDependency>());
            });
        }
    }
}