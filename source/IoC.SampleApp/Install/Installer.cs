using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IoC.SampleApp.Configuration;
using IoC.SampleApp.OnlineService;
using IoC.SampleApp.OnlineService.WebClient;
using IoC.SampleApp.ViewModel;

namespace IoC.SampleApp.Install
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // If the view is opened via a design editor, load mocked data source
            if (AppConfiguration.IsInDesignModeStatic)
            {
                container.Register(Component.For<IViewModel>().ImplementedBy<MockedViewModel>().LifestyleSingleton());
            }
            else
            {
                container.Register(Component.For<IViewModel>().ImplementedBy<MainViewModel>().LifestyleSingleton());
            }

            // Singleton = The same instance is injected for all usages
            // Transient = A new instance is created for each usage     (default, if none specified)

            // OnlineService
            container.Register(
                Component.For<IApplication>().ImplementedBy<Application>().LifestyleSingleton(),
                Component.For<IApiAdapter>().ImplementedBy<ApiAdapter>().LifestyleTransient(),
                Component.For<IWebClient>().ImplementedBy<WebClient>().LifestyleTransient()
            );
        }
    }
}