using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Moq;

namespace Test.IoC.SampleApp
{
    public class TestBase
    {
        private readonly WindsorContainer TestContainer;

        public TestBase()
        {
            TestContainer = new WindsorContainer();

            TestContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(TestContainer.Kernel));

            Install();
        }

        private void Install()
        {
            // Priority: In case there are 2+ components registered for a service, the first one has priority
            // -> First all installers of the test project and then of the application itself
            TestContainer.Install(
                FromAssembly.InThisApplication(Assembly.GetExecutingAssembly()),
                FromAssembly.Named($"{nameof(IoC)}.{nameof(SampleApp)}")
            );
        }

        /// <summary>
        /// Returns a component instance by the service, based on previously registered mocks
        /// </summary>
        public T Resolve<T>()
        {
            return TestContainer.Resolve<T>();
        }

        /// <summary>
        /// Registers the provided mock object, as default instance for the service
        /// </summary>
        public void RegisterMockOf<T>(Mock<T> mock) where T : class
        {
            TestContainer.Register(
                Component.For<T>().Instance(mock.Object)
                .IsDefault() // Force the later-registered component to become the default instance
            );
        }
    }
}