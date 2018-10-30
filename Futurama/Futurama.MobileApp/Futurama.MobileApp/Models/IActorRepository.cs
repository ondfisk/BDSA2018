using Futurama.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Futurama.MobileApp.Models
{
    public interface IActorRepository
    {
        Task<ActorDTO> CreateAsync(ActorCreateUpdateDTO actor);

        Task<ActorDTO> FindAsync(int actorId);

        Task<IEnumerable<ActorDTO>> ReadAsync();

        Task<bool> UpdateAsync(ActorCreateUpdateDTO actor);

        Task<bool> DeleteAsync(int actorId);
    }
}
