using BDSA2018.Lecture11.Entities;
using BDSA2018.Lecture11.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.Services
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly IFuturamaContext _context;

        public EpisodeRepository(IFuturamaContext context)
        {
            _context = context;
        }

        public async Task<EpisodeDetailedDTO> CreateAsync(EpisodeCreateUpdateDTO episode)
        {
            var entity = new Episode
            {
                Title = episode.Title,
                FirstAired = episode.FirstAired,
                EpisodeCharacters = episode.CharacterIds.Select(c => new EpisodeCharacter { CharacterId = c }).ToList()
            };

            _context.Episodes.Add(entity);
            await _context.SaveChangesAsync();

            return await FindAsync(entity.Id);
        }

        public async Task<EpisodeDetailedDTO> FindAsync(int episodeId)
        {
            var entities = from c in _context.Episodes
                           let f = c.EpisodeCharacters.Select(e => new { e.CharacterId, e.Character.Name })
                           where c.Id == episodeId
                           select new EpisodeDetailedDTO
                           {
                               Id = c.Id,
                               Title = c.Title,
                               FirstAired = c.FirstAired,
                               Characters = f.ToDictionary(e => e.CharacterId, e => e.Name)
                           };

            return await entities.FirstOrDefaultAsync();
        }

        public IQueryable<EpisodeDTO> Read()
        {
            var entities = from c in _context.Episodes
                           select new EpisodeDTO
                           {
                               Id = c.Id,
                               Title = c.Title,
                               FirstAired = c.FirstAired
                           };

            return entities;
        }

        public async Task<bool> UpdateAsync(EpisodeCreateUpdateDTO episode)
        {
            var entity = await _context.Episodes.Include(e => e.EpisodeCharacters).FirstOrDefaultAsync(e => e.Id == episode.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Title = episode.Title;
            entity.FirstAired = episode.FirstAired;

            var toBeAdded = episode.CharacterIds.Except(entity.EpisodeCharacters.Select(c => c.CharacterId));

            foreach (var characterId in toBeAdded)
            {
                entity.EpisodeCharacters.Add(new EpisodeCharacter { CharacterId = characterId });
            }
            foreach (var character in entity.EpisodeCharacters.ToList())
            {
                if (!episode.CharacterIds.Contains(character.CharacterId))
                {
                    entity.EpisodeCharacters.Remove(character);
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int episodeId)
        {
            var entity = await _context.Episodes.FindAsync(episodeId);

            if (entity == null)
            {
                return false;
            }

            _context.Episodes.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
