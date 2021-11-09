using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Infrastructure
{
    public interface IActorRepository:
        ISelectableRepository<Actor, int>,
        IInsertableRepository<Actor>,
        IUpdatableRepository<Actor>,
        IDeletableRepository<Actor, int>
    {
        public Task<IEnumerable<Actor>> GetAllActor();
    }
}
