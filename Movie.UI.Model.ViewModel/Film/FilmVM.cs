using Movie.Business.Manager.Model.Actor;
using Movie.Business.Manager.Model.Genre;
using Movie.UI.Model.ViewModel.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.UI.Model.ViewModel.Film
{
    public class FilmVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Imdb { get; set; }
        public DateTime RealeseDate { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<ActorForFilmDTO> Actors { get; set; }

    }
}
