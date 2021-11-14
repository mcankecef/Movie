using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Infrastructure
{
    public interface IAuthRepository :
    ISelectableRepository<User, int>,
    IUpdatableRepository<User>,
    IInsertableRepository<User>,
    IDeletableRepository<User, int>
    {
        User Get(Expression<Func<User, bool>> filter);
        List<User> GetList(Expression<Func<User, bool>> filter = null);
        User Add(User entity);
        User Update(User entity);
        void Delete(User entity);
        Task<bool> Any(Expression<Func<User, bool>> filter);
    }
}
