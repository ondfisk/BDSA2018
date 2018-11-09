using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        private readonly IReadOnlyCollection<string> _scopes;

        public CustomHttpClientHandler(ISettings settings)
        {
            _scopes = settings.Scopes;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ServerCertificateCustomValidationCallback == null && request.RequestUri.Host == "localhost")
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
