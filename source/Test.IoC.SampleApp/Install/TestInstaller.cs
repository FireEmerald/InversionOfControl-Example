using System.Diagnostics;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IoC.SampleApp.OnlineService;
using IoC.SampleApp.OnlineService.WebClient;

namespace Test.IoC.SampleApp.Install
{
    public class TestInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            /**
             * Define here any components which should be used by all tests.
             *
             * Components defined here
             * - overwrite any components from the application itself.
             * - are overwritten by mocks.
             */

            container.Register(
                // Example:
                // We don't want any communication with a real server for our tests,
                // so we set the DummyApiAdapter as default implementation for IApiAdapter.

                // Component.For<IApiAdapter>().ImplementedBy<DummyApiAdapter>()
            );

            Debug.WriteLine($"{nameof(Test)}.{nameof(TestInstaller)} registered it's components");
        }
    }
}