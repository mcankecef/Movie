using Movie.Core.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Core.Data.Repository.Infrastructure
{
    public interface ISelectableRepository<TEntity, TId>
        where TEntity : IEntity
        where TId : struct
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
