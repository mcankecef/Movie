using Movie.Business.Manager.Model.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Model.Actor
{
    public class ListActorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public float Height { get; set; }
        public DateTime BirthOfDate { get; set; }
        public ICollection<FilmForActorDTO> Films { get; set; }
    }
}
