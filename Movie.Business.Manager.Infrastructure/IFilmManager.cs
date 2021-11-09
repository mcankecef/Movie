using Movie.Business.Manager.Model.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Infrastructure
{
    public interface IFilmManager
    {
        Task<FilmDTO> CreateFilmAsync(FilmDTO film);
        Task<IEnumerable<FilmDTO>> GetAllFilm();
        //Task UpdateGenreAsync(UpdateGenreDTO genre);
        //Task<GenreDTO> GetGenreByIdAsync(int id);
        //Task DeleteGenreByIdAsync(int id);
    }
}
