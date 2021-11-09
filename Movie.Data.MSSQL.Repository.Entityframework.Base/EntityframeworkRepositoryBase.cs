using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Core.Data.Entity;
using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Context.Entityframework;

namespace Movie.Data.MSSQL.Repository.Entityframework.Base
{
    public class EntityframeworkRepositoryBase<TEntity, TId> :
        ISelectableRepository<TEntity, TId>,
        IDeletableRepository<TEntity, TId>,
        IInsertableRepository<TEntity>,
        IUpdatableRepository<TEntity>
        where TEntity:class,IEntity
        where TId:struct
    {
        public MovieDbContext _context { get; set; }
        public EntityframeworkRepositoryBase(MovieDbContext context)
        {
            _context = context;
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            entity.Status = false;

            return UpdateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(TId id)
        {
            var entity = await GetByIdAsync(id);
            _context.SaveChanges();
            return await DeleteAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {

            return await _context.Set<TEntity>()
                .Where(x=>x.Status)
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            return entity?.Status == true ? entity : null;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var inserted = await _context.Set<TEntity>().AddAsync(entity);
            _context.SaveChanges();
            return inserted.Entity;
            
        }
        public Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return Task.FromResult(1);
        }
    }
}
