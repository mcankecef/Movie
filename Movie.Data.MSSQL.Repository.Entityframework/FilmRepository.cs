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
                .Include(x=>x.Directories)
                .ToListAsync();
        }
        public async Task<Film> FilmInsertAsync(Film film)
        {

            var filmEntity = await _context.Set<Film>().AddAsync(
                new Film()
                {
                    Name = film.Name,
                    Description = film.Description,
                    ReleaseDate =Convert.ToDateTime(film.ReleaseDate.ToShortDateString()),
                    Imdb= film.Imdb,
                    Actors = new List<Actor>(film.Actors),
                    Directories = new List<Directory>(film.Directories),
                    Genres =new List<Genre>(film.Genres)
                }
                ); ;
            //var inserted = await _context.Set<Film>().AddAsync(film);
            await _context.SaveChangesAsync();
            return filmEntity.Entity;

        }

        public async Task<Film> FilmGetByIdAsync(int id)
        {
            var entity = await _context.Set<Film>()
                .Include(x => x.Actors)
                .Include(x => x.Directories)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity?.Status == true ? entity : null;
        }
        public async Task<int> FilmDeleteByIdAsync(int id)
        {
            var film = await FilmGetByIdAsync(id);
            _context.SaveChanges();
            return await FilmDeleteAsync(film);
        }
        public Task<int> FilmDeleteAsync(Film film)
        {
            film.Status = false;

            return FilmUpdateAsync(film);
        }
        public  Task<int> FilmUpdateAsync(Film film)
        {
            _context.Set<Film>().Update(
                new Film()
                {
                    Name = film.Name,
                    Description = film.Description,
                    Imdb = film.Imdb,
                    ReleaseDate = film.ReleaseDate,
                    Actors = new List<Actor>(film.Actors),
                    Directories = new List<Directory>(film.Directories),
                    Genres = new List<Genre>(film.Genres)
                });

            //_context.Set<Film>().Update(film);
            _context.SaveChanges();
            return Task.FromResult(1);
        }

    }
}
