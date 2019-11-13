using IoC.SampleApp.OnlineService;

namespace IoC.SampleApp.ViewModel
{
    public class MainViewModel : IViewModel
    {
        private readonly IApiAdapter ApiAdapter;

        public MainViewModel(IApiAdapter apiAdapter)
        {
            ApiAdapter = apiAdapter;
            InitViewModel();
        }

        public string UserName { get; private set; }
        public string FriendlyServiceStatus { get; private set; }

        private void InitViewModel()
        {
            UserName = "Logged out";
            FriendlyServiceStatus = ApiAdapter.GetServiceStatus() == ApiStatus.Ok ? "Online" : "Offline";

            // Init other properties...
        }
    }
}