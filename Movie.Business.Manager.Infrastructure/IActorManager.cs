using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Infrastructure
{
    public interface IActorManager
    {
        Task<IEnumerable<ListActorDTO>> GetAllFilm();
        Task<CreateActorDTO> CreateFilmAsync(CreateActorDTO actor);
    }
}
