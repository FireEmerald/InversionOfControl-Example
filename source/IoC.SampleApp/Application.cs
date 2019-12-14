using System;
using IoC.SampleApp.OnlineService;
using IoC.SampleApp.ViewModel;

namespace IoC.SampleApp
{
    public class Application : IApplication
    {
        public IViewModel ViewModel { get; }
        private IApiAdapter ApiAdapter { get; }

        public Application(IViewModel viewModel, IApiAdapter apiAdapter)
        {
            ViewModel = viewModel;
            ApiAdapter = apiAdapter;
        }

        public void Fly()
        {
            Console.WriteLine("   ^ ^");
            Console.WriteLine("  (O,O)");
            Console.WriteLine("  (   )");
            Console.WriteLine("  -\"-\"---");
        }
    }
}