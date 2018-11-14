using BDSA2018.Lecture11.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public interface ICharacterRepository
    {
        Task<CharacterDTO> CreateAsync(CharacterCreateUpdateDTO character);

        Task<CharacterDTO> FindAsync(int characterId);

        Task<IEnumerable<CharacterDTO>> ReadAsync();

        Task<bool> UpdateAsync(CharacterCreateUpdateDTO character);

        Task<bool> DeleteAsync(int characterId);
    }
}
