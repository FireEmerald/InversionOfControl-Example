namespace IoC.SampleApp.OnlineService.Routes
{
    public class GetStatusRoute : IRoute
    {
        public bool IsMatching(string key)
        {
            return key == "status";
        }

        public string GetRoute => "/getStatus";
    }
}