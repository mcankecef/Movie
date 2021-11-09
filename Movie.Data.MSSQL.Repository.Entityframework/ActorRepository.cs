using Microsoft.EntityFrameworkCore;
using Movie.Data.MSSQL.Context.Entityframework;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Entityframework.Base;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Entityframework
{
    public class ActorRepository : EntityframeworkRepositoryBase<Actor, int>, IActorRepository
    {
        public ActorRepository(MovieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Actor>> GetAllActor()
        {

            return await _context.Set<Actor>()
                .Where(x => x.Status).Include(x => x.Films)
                .ToListAsync();
        }

  
    }
}
