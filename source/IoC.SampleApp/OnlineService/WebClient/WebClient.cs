namespace IoC.SampleApp.OnlineService.WebClient
{
    public class WebClient : IWebClient
    {
        public string Request(string url)
        {
            return "{ success: true }"; // Some HTTP request
        }
    }
}