using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public class BearerTokenHttpClientHandler : HttpClientHandler
    {
        private readonly IPublicClientApplication _publicClientApplication;
        private readonly ISettings _settings;

        public BearerTokenHttpClientHandler(IPublicClientApplication publicClientApplication, ISettings settings)
        {
            _publicClientApplication = publicClientApplication;
            _settings = settings;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ServerCertificateCustomValidationCallback == null && request.RequestUri.Host == "localhost")
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            }

            var account = await GetAccountByPolicyAsync(_settings.SignUpSignInPolicy);

            var authenticationResult = await _publicClientApplication.AcquireTokenSilentAsync(_settings.Scopes, account, _settings.Authority, false);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<IAccount> GetAccountByPolicyAsync(string policy)
        {
            var accounts = await _publicClientApplication.GetAccountsAsync();

            foreach (var account in accounts)
            {
                var userIdentifier = account.HomeAccountId.ObjectId.Split('.')[0];

                if (userIdentifier.EndsWith(policy, StringComparison.OrdinalIgnoreCase))
                {
                    return account;
                }
            }

            return null;
        }
    }
}
