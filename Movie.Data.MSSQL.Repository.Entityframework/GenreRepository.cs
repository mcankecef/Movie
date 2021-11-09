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
    public class GenreRepository : EntityframeworkRepositoryBase<Genre, int>, IGenreRepository
    {
        public GenreRepository(MovieDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Genre>> GetAllGenre()
        {
            return await _context.Set<Genre>()
                .Where(x => x.Status).Include(x => x.Films)
                .ToListAsync();
        }
    }
}
