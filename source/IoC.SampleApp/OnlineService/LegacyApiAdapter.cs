using Castle.Core.Internal;
using IoC.SampleApp.OnlineService.WebClient;

namespace IoC.SampleApp.OnlineService
{
    public class LegacyApiAdapter : IApiAdapter
    {
        private const string API_ENDPOINT = "http://example.com/api/v1";

        private readonly IWebClient WebClient;

        public LegacyApiAdapter(IWebClient webClient)
        {
            WebClient = webClient;
        }

        public ApiStatus GetServiceStatus()
        {
            // The legacy api/v1 component, does not have any authentication.
            return WebClient.Request(API_ENDPOINT + "/getStatus").IsNullOrEmpty() ? ApiStatus.ServerError : ApiStatus.Ok;
        }
    }
}