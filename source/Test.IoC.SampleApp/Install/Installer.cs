using System.Diagnostics;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Test.IoC.SampleApp.Install
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                /**
                 * Define here any changes for all tests.
                 *
                 * Components defined here
                 * - overwrite any components from the application itself.
                 * - are overwritten by mocks.
                 */
            );

            Debug.WriteLine($"{nameof(Test)}.{nameof(Installer)} registered it's components");
        }
    }
}