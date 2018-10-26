using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2018.Lecture09.MVVM.Model
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> ReadAsync();
    }
}