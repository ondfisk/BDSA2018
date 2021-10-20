using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public class BearerTokenHttpClientHandler : HttpClientHandler
    {
        private readonly IPublicClientApplication _publicClientApplication;
        private readonly IReadOnlyCollection<string> _scopes;

        public BearerTokenHttpClientHandler(IPublicClientApplication publicClientApplication, ISettings settings)
        {
            _publicClientApplication = publicClientApplication;
            _scopes = settings.Scopes;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ServerCertificateCustomValidationCallback == null && request.RequestUri.Host == "localhost")
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            }

            var accounts = await _publicClientApplication.GetAccountsAsync();

            var result = await _publicClientApplication.AcquireTokenSilent(_scopes, accounts.First()).ExecuteAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
