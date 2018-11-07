using BDSA2018.Lecture10.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public class ActorRepository : IActorRepository
    {
        private readonly HttpClient _client;

        public ActorRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<ActorDTO> CreateAsync(ActorCreateUpdateDTO actor)
        {
            var response = await _client.PostAsJsonAsync("api/actors", actor);

            return await response.Content.ReadAsAsync<ActorDTO>();
        }

        public async Task<bool> DeleteAsync(int actorId)
        {
            var response = await _client.DeleteAsync($"api/actors/{actorId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<ActorDTO> FindAsync(int actorId)
        {
            var response = await _client.GetAsync($"api/actors/{actorId}");

            return await response.Content.ReadAsAsync<ActorDTO>();
        }

        public async Task<IEnumerable<ActorDTO>> ReadAsync()
        {
            var response = await _client.GetAsync("api/actors");

            return await response.Content.ReadAsAsync<IEnumerable<ActorDTO>>();
        }

        public async Task<bool> UpdateAsync(ActorCreateUpdateDTO actor)
        {
            var response = await _client.PutAsJsonAsync($"api/actors/{actor.Id}", actor);

            return response.IsSuccessStatusCode;
        }
    }
}
