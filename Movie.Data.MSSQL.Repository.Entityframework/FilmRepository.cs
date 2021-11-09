using Microsoft.EntityFrameworkCore;
using Movie.Data.MSSQL.Context.Entityframework;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Entityframework.Base;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Entityframework
{
    public class FilmRepository : EntityframeworkRepositoryBase<Film, int>, IFilmRepository
    {
        public FilmRepository(MovieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Film>> GetAllFilm()
        {
            return await _context.Set<Film>()
                .Where(x => x.Status)
                .Include(x=>x.Genres)
                .Include(x=>x.Actors)
                .ToListAsync();
        }
        public async Task<Film> FilmInsertAsync(Film film)
        {
            var inserted = await _context.Set<Film>().AddAsync(film);
            _context.SaveChanges();
            return inserted.Entity;

        }
    }
}
