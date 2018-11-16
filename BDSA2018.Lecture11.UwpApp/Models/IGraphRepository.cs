using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public interface IGraphRepository
    {
        Task<User> ReadAsync();
        Task<IEnumerable<System.Security.Claims.Claim>> ReadClaimsAsync();
    }
}