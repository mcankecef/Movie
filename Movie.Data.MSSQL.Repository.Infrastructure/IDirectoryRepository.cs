using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Infrastructure
{
    public interface IDirectoryRepository:
        ISelectableRepository<Directory, int>,
        IInsertableRepository<Directory>,
        IUpdatableRepository<Directory>,
        IDeletableRepository<Directory, int>
    {
        Task<IEnumerable<Directory>> GetAllDirectory();
    }
}
