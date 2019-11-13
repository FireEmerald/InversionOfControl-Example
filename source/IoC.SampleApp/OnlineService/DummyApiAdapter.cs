namespace IoC.SampleApp.OnlineService
{
    /// <summary>
    /// A dummy class which could be used as mock
    /// </summary>
    public class DummyApiAdapter : IApiAdapter
    {
        public ApiStatus GetServiceStatus() => ApiStatus.Ok;
    }
}