using Futurama.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Futurama.MobileApp.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly HttpClient _client;

        public CharacterRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CharacterDTO> CreateAsync(CharacterCreateUpdateDTO character)
        {
            var response = await _client.PostAsJsonAsync("api/characters", character);

            return await response.Content.ReadAsAsync<CharacterDTO>();
        }

        public async Task<bool> DeleteAsync(int characterId)
        {
            var response = await _client.DeleteAsync($"api/characters/{characterId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<CharacterDTO> FindAsync(int characterId)
        {
            var response = await _client.GetAsync($"api/characters/{characterId}");

            return await response.Content.ReadAsAsync<CharacterDTO>();
        }

        public async Task<IEnumerable<CharacterDTO>> ReadAsync()
        {
            var response = await _client.GetAsync("api/characters");

            return await response.Content.ReadAsAsync<IEnumerable<CharacterDTO>>();
        }

        public async Task<bool> UpdateAsync(CharacterCreateUpdateDTO character)
        {
            var response = await _client.PutAsJsonAsync($"api/characters/{character.Id}", character);

            return response.IsSuccessStatusCode;
        }
    }
}
