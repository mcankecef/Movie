using Movie.Core.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Core.Data.Repository.Infrastructure
{
    public interface IUpdatableRepository<T> where T : IEntity
    {
        Task<int> UpdateAsync(T entity);
    }
}
