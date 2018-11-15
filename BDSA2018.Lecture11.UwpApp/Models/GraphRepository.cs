using System.Net.Http;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public class GraphRepository : IGraphRepository
    {
        private readonly HttpClient _client;

        public GraphRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<User> ReadAsync()
        {
            var response = await _client.GetAsync("me");

            return await response.Content.ReadAsAsync<User>();
        }
    }
}
