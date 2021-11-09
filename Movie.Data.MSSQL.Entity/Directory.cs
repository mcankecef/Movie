using Movie.Core.Data.Entity;
using Movie.Data.MSSQL.Entity.Base;
using System;
using System.Collections.Generic;

namespace Movie.Data.MSSQL.Entity
{
    public class Directory : EntityBase, IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthOfDate { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
