using Movie.Core.Data.Entity;
using System.Threading.Tasks;

namespace Movie.Core.Data.Repository.Infrastructure
{
    public interface IInsertableRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> InsertAsync(TEntity entity);
    }

}
