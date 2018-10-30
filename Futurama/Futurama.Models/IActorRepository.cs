using Futurama.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace Futurama.Models
{
    public interface IActorRepository
    {
        Task<ActorDetailedDTO> CreateAsync(ActorCreateUpdateDTO actor);

        Task<ActorDetailedDTO> FindAsync(int actorId);

        IQueryable<ActorDTO> Read();

        Task<bool> UpdateAsync(ActorCreateUpdateDTO actor);

        Task<bool> DeleteAsync(int actorId);
    }
}
