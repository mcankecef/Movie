using Movie.Core.Data.Entity;
using Movie.Data.MSSQL.Entity.Base;
using System.Collections.Generic;

namespace Movie.Data.MSSQL.Entity
{
    public class Genre : EntityBase, IEntity<int>
    {
        public int Id { get; set; }
        public string GenreOfFilm { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
