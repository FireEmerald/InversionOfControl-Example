using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IoC.SampleApp.Configuration;
using IoC.SampleApp.OnlineService;
using IoC.SampleApp.OnlineService.Routes;
using IoC.SampleApp.OnlineService.WebClient;
using IoC.SampleApp.ViewModel;

namespace IoC.SampleApp.Install
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Registration of components, based on if the view is opened via a design editor (> register mock class)
            if (AppConfiguration.IsInDesignModeStatic) {
                container.Register(
                    Component.For<IViewModel>().ImplementedBy<MockedViewModel>().LifestyleSingleton()
                );
            } else {
                container.Register(
                    Component.For<IViewModel>().ImplementedBy<MainViewModel>().LifestyleSingleton()
                );
            }

            // Registration of all classes which implement IRoute
            container.Register(
                Classes.FromAssemblyContaining<IRoute>().BasedOn<IRoute>()
                    .WithService.FromInterface().LifestyleTransient()
            );

            // Registration of components one-by-one
            container.Register(
                Component.For<IWebClient>().ImplementedBy<WebClient>().LifestyleTransient(),
                Component.For<IApiAdapter>().ImplementedBy<ApiAdapter>().LifestyleTransient(),

                // It's e.g. also possible to execute certain actions on instance create
                Component.For<IApplication>().ImplementedBy<Application>().LifestyleTransient()
                    .OnCreate((kernel, instance) => Debug.WriteLine($"{nameof(Application)} created with {instance.ViewModel.UserName}"))

                /**
                 * Lifestyles:
                 *
                 * Singleton = The same instance is injected for each usage
                 * Transient = A new instance of the class is created for each usage
                 */
            );

            /**
             * There are many other options to register classes.
             *
             * For example you could use "Types" as shown below,
             * to register all classes which implement at least one interface.
             *
             * container.Register(
             *     Types.FromAssembly(Assembly.GetExecutingAssembly())
             *         .Where(type => type.IsClass && type.GetInterfaces().Any())
             *         .WithService.DefaultInterfaces()
             * );
             *
             * This could replace every registration from above, but without any specifications - not clean!
             */

            Debug.WriteLine($"{nameof(Installer)} registered it's components");
        }
    }
}