using Movie.Business.Manager.Model.Directory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Infrastructure
{
    public interface IDirectoryManager
    {
        Task<IEnumerable<ListDirectoryDTO>> ListDirectoryAsync();
        Task<CreateDirectoryDTO> CreateDirectoryAsync(CreateDirectoryDTO directory);
        Task UpdateDirectoryAsync(UpdateDirectoryDTO directory);
        Task<DirectoryDTO> GetDirectoryByIdAsync(int id);
        Task DeleteDirectoryByIdAsync(int id);

    }
}
