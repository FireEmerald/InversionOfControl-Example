using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using IoC.SampleApp.OnlineService.Routes;
using IoC.SampleApp.OnlineService.WebClient;

namespace IoC.SampleApp.OnlineService
{
    public class ApiAdapter : IApiAdapter
    {
        private const string API_ENDPOINT = "https://example.com/api/v2";

        private readonly IWebClient WebClient;
        private readonly IList<IRoute> Routes;

        public ApiAdapter(IWebClient webClient, IList<IRoute> routes)
        {
            WebClient = webClient;
            Routes = routes;
        }

        public ApiStatus GetServiceStatus()
        {
            if (AuthenticationFailed())
                return ApiStatus.ClientError;

            IRoute route = Routes.Single(r => r.IsMatching("status"));

            return WebClient.Request(API_ENDPOINT + route.GetRoute).IsNullOrEmpty() ? ApiStatus.ServerError : ApiStatus.Ok;
        }

        /// <summary>
        /// Basic authentication of the user, only required in api/v2.
        /// </summary>
        private bool AuthenticationFailed()
        {
            IRoute route = Routes.Single(r => r.IsMatching("auth"));

            return WebClient.Request(API_ENDPOINT + route.GetRoute).IsNullOrEmpty();
        }
    }
}