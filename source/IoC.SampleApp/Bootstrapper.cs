using System.Reflection;
using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace IoC.SampleApp
{
    public class Bootstrapper
    {
        private readonly IWindsorContainer Container;

        public Bootstrapper()
        {
            // The container which will hold all registered classes, used for resolving dependencies later
            Container = new WindsorContainer();

            // Adds support for resolving IEnumerable<T>, ICollection<T>, IList<T> or T[] collection types
            Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));

            // There are also other types of Resolvers available:
            // https://github.com/castleproject/Windsor/blob/master/docs/resolvers.md
            // A resolver must be added, before any component was registered!
        }

        public void Install()
        {
            // Magic: Calls each class which implements IWindsorInstaller, within this application
            // -> In our case this is only Install/Installer.cs
            Container.Install(FromAssembly.InThisApplication(Assembly.GetExecutingAssembly()));
        }

        public void Start()
        {
            // Create a instance of the Application, dependencies are resolved automatically based on components from the Container
            var app = Container.Resolve<IApplication>();
            app.Fly();
        }
    }
}