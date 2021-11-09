using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Infrastructure
{
    public interface IGenreRepository:
        ISelectableRepository<Genre,int>,
        IInsertableRepository<Genre>,
        IUpdatableRepository<Genre>,
        IDeletableRepository<Genre,int>
    {
        Task<IEnumerable<Genre>> GetAllGenre();
    }
}
