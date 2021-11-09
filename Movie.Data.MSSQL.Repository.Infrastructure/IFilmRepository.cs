using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Infrastructure
{
    public interface IFilmRepository :
        ISelectableRepository<Film, int>,
        IInsertableRepository<Film>,
        IUpdatableRepository<Film>,
        IDeletableRepository<Film, int>
    {
        Task<IEnumerable<Film>> GetAllFilm();
        Task<Film> FilmInsertAsync(Film film);
    }
}
