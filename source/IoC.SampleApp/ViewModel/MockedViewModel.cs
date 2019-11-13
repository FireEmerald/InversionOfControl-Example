namespace IoC.SampleApp.ViewModel
{
    public class MockedViewModel : IViewModel
    {
        public string UserName => "Doe John";
        public string FriendlyServiceStatus => "Online";
    }
}