namespace Movie.Data.MSSQL.Entity.Base
{
    public class EntityBase
    {
        public bool Status { get; set; }
        public EntityBase()
        {
            Status = true;
        }
    }
}
