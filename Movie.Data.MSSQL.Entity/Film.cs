using Movie.Core.Data.Entity;
using Movie.Data.MSSQL.Entity.Base;
using System;
using System.Collections.Generic;

namespace Movie.Data.MSSQL.Entity
{
    public class Film : EntityBase, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Imdb { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Directory> Directories { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
