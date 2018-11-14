using BDSA2018.Lecture11.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
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
