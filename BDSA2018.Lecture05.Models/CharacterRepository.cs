using BDSA2018.Lecture05.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2018.Lecture05.Models
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
            throw new System.NotImplementedException();
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

        public CharacterDTO Find(int characterId)
        {
            //var entity = _context.Characters.Include(c => c.Actor).
            //    FirstOrDefault(c => c.Id == characterId);
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
                               NumberOfEpisodes = c.EpisodeCharacters.Count()
                           };

            return entities.ToList().AsReadOnly();
        }

        public void Update(CharacterCreateUpdateDTO character)
        {
            throw new System.NotImplementedException();
        }
    }
}
