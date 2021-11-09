using Movie.Core.Data.Entity;
using System.Threading.Tasks;

namespace Movie.Core.Data.Repository.Infrastructure
{
    public interface IDeletableRepository<TEntity,TId>
        where TEntity : IEntity
        where TId :struct
    {
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteByIdAsync(TId id);
    }
}
