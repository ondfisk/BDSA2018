using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public interface IGraphRepository
    {
        Task<User> ReadAsync();
    }
}