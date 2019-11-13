using IoC.SampleApp.ViewModel;

namespace IoC.SampleApp
{
    public interface IApplication
    {
        IViewModel ViewModel { get; }
        void Fly();
    }
}