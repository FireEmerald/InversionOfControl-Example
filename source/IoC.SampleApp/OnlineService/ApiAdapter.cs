using Castle.Core.Internal;
using IoC.SampleApp.OnlineService.WebClient;

namespace IoC.SampleApp.OnlineService
{
    public class ApiAdapter : IApiAdapter
    {
        private const string API_ENDPOINT = "https://example.com/api/v2";

        private readonly IWebClient WebClient;

        public ApiAdapter(IWebClient webClient)
        {
            WebClient = webClient;
        }

        public ApiStatus GetServiceStatus()
        {
            if (AuthenticationFailed())
                return ApiStatus.ClientError;

            return WebClient.Request(API_ENDPOINT + "/getStatus").IsNullOrEmpty() ? ApiStatus.ServerError : ApiStatus.Ok;
        }

        /// <summary>
        /// Basic authentication of the user, only required in api/v2.
        /// </summary>
        private bool AuthenticationFailed()
        {
            return WebClient.Request(API_ENDPOINT + "/auth").IsNullOrEmpty();
        }
    }
}