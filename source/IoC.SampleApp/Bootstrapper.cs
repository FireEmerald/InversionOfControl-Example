using System.Reflection;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace IoC.SampleApp
{
    public class Bootstrapper
    {
        public readonly IWindsorContainer Container;

        public Bootstrapper()
        {
            Container = new WindsorContainer();

            Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));
        }

        public void Install()
        {
            // Calls each IWindsorInstaller class within this application
            Container.Install(FromAssembly.InThisApplication(Assembly.GetExecutingAssembly()));
        }

        public void Start()
        {
            // Ready to rumble
            var app = Container.Resolve<IApplication>();
            app.Fly();
        }
    }
}