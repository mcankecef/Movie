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
    public class DirectoryRepository : EntityframeworkRepositoryBase<Directory, int>,IDirectoryRepository
    {
        public DirectoryRepository(MovieDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Directory>> GetAllDirectory()
        {
            return await _context.Set<Directory>()
                .Where(x => x.Status).Include(x => x.Films)
                .ToListAsync();
        }
    }
}
