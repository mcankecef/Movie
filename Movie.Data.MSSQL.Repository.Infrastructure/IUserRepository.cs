using Movie.Core.Data.Repository.Infrastructure;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Infrastructure
{
    public interface IUserRepository:
        ISelectableRepository<User,int>,
        IUpdatableRepository<User>,
        IInsertableRepository<User>,
        IDeletableRepository<User,int>
    {
    }
}
