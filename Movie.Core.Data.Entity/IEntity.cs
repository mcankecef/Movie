namespace Movie.Core.Data.Entity
{
    public interface IEntity
    {
        public bool Status { get; set; }
    }
    public interface IEntity<T>:IEntity where T : struct
    {
        public T Id { get; set; }
    }
}
