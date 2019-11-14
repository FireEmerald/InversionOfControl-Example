namespace IoC.SampleApp.OnlineService.Routes
{
    public interface IRoute
    {
        bool IsMatching(string key);
        string GetRoute { get; }
    }
}