using System;

namespace IoC.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Install();
            bootstrapper.Start();
            
            Console.WriteLine("App is running!");
        }
    }
}
