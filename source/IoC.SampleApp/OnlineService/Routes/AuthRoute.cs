namespace IoC.SampleApp.OnlineService.Routes
{
    public class AuthRoute : IRoute
    {
        public bool IsMatching(string key)
        {
            return key == "auth";
        }

        public string GetRoute => "/authUser";
    }
}