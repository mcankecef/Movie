using Movie.Core.Data.Entity;
using Movie.Data.MSSQL.Entity.Base;

namespace Movie.Data.MSSQL.Entity
{
    public class User : EntityBase,IEntity<int>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
