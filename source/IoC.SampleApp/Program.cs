using System;
using System.Diagnostics;

namespace IoC.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Install();
            bootstrapper.Start();
            
            Debug.WriteLine("App is running!");
            Console.ReadKey();
        }
    }
}
