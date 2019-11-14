using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using IoC.SampleApp.OnlineService.Routes;
using IoC.SampleApp.OnlineService.WebClient;

namespace IoC.SampleApp.OnlineService
{
    public class LegacyApiAdapter : IApiAdapter
    {
        private const string API_ENDPOINT = "http://example.com/api/v1";

        private readonly IWebClient WebClient;
        private readonly IList<IRoute> Routes;

        public LegacyApiAdapter(IWebClient webClient, IList<IRoute> routes)
        {
            WebClient = webClient;
            Routes = routes;
        }

        public ApiStatus GetServiceStatus()
        {
            IRoute route = Routes.Single(r => r.IsMatching("auth"));

            // The legacy api/v1 component, does not have any authentication.
            return WebClient.Request(API_ENDPOINT + route.GetRoute).IsNullOrEmpty() ? ApiStatus.ServerError : ApiStatus.Ok;
        }
    }
}