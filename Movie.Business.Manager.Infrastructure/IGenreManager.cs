using Movie.Business.Manager.Model.Genre;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Infrastructure
{
    public interface IGenreManager
    {
        Task<GenreDTO> CreateGenreAsync(CreateGenreDTO genre);
        Task<IEnumerable<ListGenreDTO>> GetAllGenre();
        Task UpdateGenreAsync(UpdateGenreDTO genre);
        Task<GenreDTO> GetGenreByIdAsync(int id);
        Task DeleteGenreByIdAsync(int id);

    }
}
