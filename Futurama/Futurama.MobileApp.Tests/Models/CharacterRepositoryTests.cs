using Futurama.MobileApp.Models;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Futurama.MobileApp.Tests.Models
{
    public class CharacterRepositoryTests
    {
        [Fact]
        public async Task DeleteAsync_sends_delete()
        {
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                   .Setup<Task<HttpResponseMessage>>(
                      "SendAsync",
                      ItExpr.IsAny<HttpRequestMessage>(),
                      ItExpr.IsAny<CancellationToken>()
                   )
                   .ReturnsAsync(new HttpResponseMessage
                   {
                       StatusCode = HttpStatusCode.NoContent
                   });

            var client = new HttpClient(handler.Object)
            {
                BaseAddress = new Uri("https://futurama.com/"),
            };

            var repository = new CharacterRepository(client);

            var result = await repository.DeleteAsync(42);

            Assert.True(result);

            handler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Delete 
                  && req.RequestUri == new Uri("https://futurama.com/api/characters/42")
                ),
                   ItExpr.IsAny<CancellationToken>()
                );
        }
    }
}
