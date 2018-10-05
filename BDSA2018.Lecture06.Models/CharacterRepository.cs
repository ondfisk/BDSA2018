using BDSA2018.Lecture06.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2018.Lecture06.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IFuturamaContext _context;

        public CharacterRepository(IFuturamaContext context)
        {
            _context = context;
        }

        public int Create(CharacterCreateUpdateDTO character)
        {
            var entity = new Character
            {
                ActorId = character.ActorId,
                Name = character.Name,
                Species = character.Species,
                Planet = character.Planet,
            };

            _context.Characters.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public CharacterDTO Find(int characterId)
        {
            var entities = from c in _context.Characters
                           where c.Id == characterId
                           select new CharacterDTO
                           {
                               Id = c.Id,
                               Name = c.Name,
                               Species = c.Species,
                               Planet = c.Planet,
                               ActorId = c.ActorId,
                               ActorName = c.Actor.Name,
                               NumberOfEpisodes = c.EpisodeCharacters.Count()
                           };

            return entities.FirstOrDefault();
        }

        public IReadOnlyCollection<CharacterDTO> Read()
        {
            var entities = from c in _context.Characters
                           select new CharacterDTO
                           {
                               Id = c.Id,
                               Name = c.Name,
                               Species = c.Species,
                               Planet = c.Planet,
                               ActorId = c.ActorId,
                               ActorName = c.Actor.Name,
                               NumberOfEpisodes = c.EpisodeCharacters.Count()
                           };

            return entities.ToList().AsReadOnly();
        }

        public bool Update(CharacterCreateUpdateDTO character)
        {
            var entity = _context.Characters.Find(character.Id);

            if (entity == null)
            {
                return false;
            }

            entity.ActorId = character.ActorId;
            entity.Name = character.Name;
            entity.Species = character.Species;
            entity.Planet = character.Planet;
           
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int characterId)
        {
            var entity = _context.Characters.Find(characterId);

            if (entity == null)
            {
                return false;
            }

            _context.Characters.Remove(entity);

            _context.SaveChanges();

            return true;
        }
    }
}
