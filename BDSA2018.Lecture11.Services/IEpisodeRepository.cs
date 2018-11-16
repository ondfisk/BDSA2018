using BDSA2018.Lecture11.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.Services
{
    public interface IEpisodeRepository
    {
        Task<EpisodeDetailedDTO> CreateAsync(EpisodeCreateUpdateDTO character);

        Task<EpisodeDetailedDTO> FindAsync(int characterId);

        IQueryable<EpisodeDTO> Read();

        Task<bool> UpdateAsync(EpisodeCreateUpdateDTO character);

        Task<bool> DeleteAsync(int characterId);
    }
}
