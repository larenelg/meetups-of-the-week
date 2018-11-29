using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace DataDrivenDiversity.Api
{
    public class ApiKeyHandler : DelegatingHandler
    {
        private readonly IConfiguration _configuration;

        public ApiKeyHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            var queryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

            queryString.Add("key", _configuration.GetValue<string>("MeetupApiKey"));

            var uriBuilder = new UriBuilder(request.RequestUri);
            uriBuilder.Query = queryString.ToString();

            request.RequestUri = uriBuilder.Uri;

            return await base.SendAsync(request, cancellationToken);
        }
    }
}