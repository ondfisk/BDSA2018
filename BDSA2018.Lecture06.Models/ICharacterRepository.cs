using System.Collections.Generic;

namespace BDSA2018.Lecture06.Models
{
    public interface ICharacterRepository
    {
        int Create(CharacterCreateUpdateDTO character);

        CharacterDTO Find(int characterId);

        IReadOnlyCollection<CharacterDTO> Read();

        bool Update(CharacterCreateUpdateDTO character);

        bool Delete(int characterId);
    }
}
