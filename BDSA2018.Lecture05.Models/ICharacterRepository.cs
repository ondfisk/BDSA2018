using System.Collections.Generic;

namespace BDSA2018.Lecture05.Models
{
    public interface ICharacterRepository
    {
        int Create(CharacterCreateUpdateDTO character);

        CharacterDTO Find(int characterId);

        IReadOnlyCollection<CharacterDTO> Read();

        void Update(CharacterCreateUpdateDTO character);

        bool Delete(int characterId);
    }
}
