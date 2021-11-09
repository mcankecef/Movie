using Movie.Data.MSSQL.Context.Entityframework;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Entityframework.Base;
using Movie.Data.MSSQL.Repository.Infrastructure;

namespace Movie.Data.MSSQL.Repository.Entityframework
{
    public class UserRepository : EntityframeworkRepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
